using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Models;
using System.IO;
using Newtonsoft.Json;

namespace ProjectManagement.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentController : Controller
    {

        // GET: Student
        public ActionResult Index()
        {
            using (ProjectContext pc=new ProjectContext()) {
                
                Student std=pc.Students.FirstOrDefault(s=>s.Id==User.Identity.Name);
                
                return View(std);
            }
               
        }
        public ActionResult pending_projects() {
            using (ProjectContext pc = new ProjectContext())
            {
                Student std = pc.Students.FirstOrDefault(s => s.Id == User.Identity.Name);
               // this.student = std;
                // List<CreateProject> cp = pc.CreatedProject.Where(s => s.Psem == this.student.semester && s.PTarYear == this.student.joinYear && ).ToList();
                //return View(std);

                
                List<CreateProject> cp = (from project in pc.CreatedProject
                                         join faculty in pc.Students on project.FacultyId equals faculty.Id
                                         where project.PTarYear == std.joinYear && project.Psem == std.semester && faculty.Dept ==std.Dept
                                         && DateTime.Compare(project.SelectionDeadline,DateTime.Now)>0
                                         select project).ToList();

                List<int> selected = (from ac in pc.ActiveProject
                                               where ac.member2_id == User.Identity.Name || ac.member3_id == User.Identity.Name
                                                || ac.member1_id == User.Identity.Name select ac.Pid).ToList();

                cp.RemoveAll(x => selected.Contains(x.Pid));
               
                return View(cp);
            }
         

        }

        public ActionResult select_project(int id) {

            TempData["pid"] = id;
            return View();

        }
        [HttpPost]
        public ActionResult select_project(ActiveProject ap)
        {
            int id = int.Parse(TempData["pid"].ToString());
            System.Diagnostics.Debug.WriteLine("ID " + id);
            ap.Pid = id;
            using (ProjectContext pc=new ProjectContext()) {
               string fid= pc.CreatedProject.FirstOrDefault(s=>s.Pid==id).FacultyId.ToString();
                ap.FacultyId = fid;
            }
            ap.SelectionDate = DateTime.Now;
            
            using (ProjectContext pc = new ProjectContext()) {
                pc.ActiveProject.Add(ap);
                pc.SaveChanges();

            }
            return Redirect("~/Student/Index");

        }
        public ActionResult selected_project()
        {
            
            using (ProjectContext pc=new ProjectContext()) {
                
               //List<ActiveProject> ap= pc.ActiveProject.Where(s => s.member1_id == User.Identity.Name || s.member2_id == User.Identity.Name || s.member3_id == User.Identity.Name).ToList();
                List<ActiveProject> ap1=(from active in pc.ActiveProject join 
                                        create in pc.CreatedProject on active.Pid equals create.Pid
                                        where (active.member1_id == User.Identity.Name || active.member2_id == User.Identity.Name || active.member3_id == User.Identity.Name) &&
                                        DateTime.Compare(create.SubmissionDeadline, DateTime.Now) > 0 select active).ToList();
                List<int> ap2 = (from active in pc.ActiveProject
                                           join ev in pc.ProjectEvaluation
                                            on active.Pid equals ev.Pid
                                           where (active.member1_id == User.Identity.Name || active.member2_id == User.Identity.Name || active.member3_id == User.Identity.Name)
                                           select active.Pid
                                         ).ToList();
                ap1.RemoveAll(x=>ap2.Contains(x.Pid));
              
                 return View(ap1);

            }
                

        }
        public ActionResult project_details(int id) {

            using (ProjectContext pc=new ProjectContext()) {
                CreateProject cp=pc.CreatedProject.FirstOrDefault(x => x.Pid == id);
                return View(cp);
            }
                
        }
        //Projectfile Upload
       [HttpPost]
       public ActionResult submit_project(int id,HttpPostedFileBase file)
        {
            string file_path = Server.MapPath("~/UploadedProject");
            string file_name = Path.GetFileName(file.FileName);
            string full_path = Path.Combine(file_path, file_name);

            using (ProjectContext pc = new ProjectContext())
            {
                SubmittedProject sp = new SubmittedProject();
                sp.member1_id = User.Identity.Name;
                sp.Pid = id;
                sp.ProjectFile = full_path.ToString();
                sp.ProjectSubmitted = DateTime.Now;
                pc.SubmittedProject.Add(sp);
               // pc.ActiveProject.Remove(pc.ActiveProject.FirstOrDefault(x => x.Pid == id && (x.member2_id == sp.member1_id || x.member1_id == sp.member1_id || x.member3_id == sp.member1_id)));
                pc.SaveChanges();
                
            }
            file.SaveAs(full_path);
            return Redirect("~/Student/Index");
        }

        public ActionResult submitted_project() {
            using (ProjectContext pc =new ProjectContext()) {
                List<ProjectEvaluation> sp = pc.ProjectEvaluation.Where(x => x.member1_id == User.Identity.Name || x.member2_id == User.Identity.Name || x.member3_id == User.Identity.Name).ToList();
                String[] pdef = (from pe in pc.ProjectEvaluation
                                          join cr  in pc.CreatedProject on  pe.Pid equals cr.Pid
                                          where  pe.member1_id == User.Identity.Name || pe.member2_id == User.Identity.Name ||
                                          pe.member3_id == User.Identity.Name 
                                          select cr.Pdef).ToArray();
                System.Diagnostics.Debug.WriteLine("Title : "+ pdef[0]);
                for (int i = 0; i < pdef.Length; i++)
                {
                    ViewData["" + i] = pdef[i];
                }
                return View(sp);
            }
            
        }

        public ActionResult analyze_performance()
        {
            int[] sum = new int[8];
            int[] total = new int[8];
            double[] percentage = new double[8];
            using (ProjectContext pc = new ProjectContext())
            {
                //Evaluated Project of Current STudent
                List<ProjectEvaluation> pe = pc.ProjectEvaluation.Where(x => x.member1_id == User.Identity.Name ||
                                            x.member2_id == User.Identity.Name || x.member3_id == User.Identity.Name).ToList();
                //Same ProjectID current user creater project
                List<CreateProject> cp = (from create in pc.CreatedProject join
                                          eval in pc.ProjectEvaluation on create.Pid equals eval.Pid
                                          where eval.member1_id == User.Identity.Name || eval.member2_id == User.Identity.Name
                                          || eval.member3_id == User.Identity.Name select create).ToList();
                for (int i = 0; i < 8; i++)
                {
                    sum[i] = 0;
                    total[i] = 0;
                    percentage[i] = 0.0;
                    foreach (var item in cp)
                    {
                        if (item.Psem == i+1)
                        {
                            foreach (var data in pe)
                            {
                                if (data.member1_id == User.Identity.Name)
                                {
                                    sum[i] = sum[i] + data.mem1_marks;
                                    
                                }
                                else if (data.member2_id == User.Identity.Name)
                                {
                                    sum[i] = sum[i] + data.mem2_marks;
                                }
                                else {
                                    sum[i] = sum[i] + data.mem3_marks;
                                }
                                total[i] = total[i] + data.totmarks;

                            }
                        }
                        
                    }
                    System.Diagnostics.Debug.WriteLine(total[i] + "  ");
                    if (total[i] > 0)
                        percentage[i] = ((double)sum[i] / (double)total[i]) * 100;
                    else
                        percentage[i] = 0.0;
                   
                    System.Diagnostics.Debug.WriteLine(percentage[i] + "  ");
                }
                ViewBag.marks = percentage;
               

            }
                return View();
        }
        

    }
}