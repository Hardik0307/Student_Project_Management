using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Models;
using System.IO;

namespace ProjectManagement.Controllers
{
    [Authorize(Roles ="Faculty")]
    public class FacultyController : Controller
    {
       
        public ActionResult Index()
        {
            using (ProjectContext pc = new ProjectContext())
            {

                Student std = pc.Students.FirstOrDefault(s => s.Id == User.Identity.Name);

                return View(std);
            }

        }

        public ActionResult Create_project()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create_project(CreateProject p)
        {
            p.FacultyId = User.Identity.Name;
            using (ProjectContext pc=new ProjectContext()) {
                pc.CreatedProject.Add(p);
                pc.SaveChanges();
            }

            return Redirect("~/Faculty/Created_project");
        }

        public ActionResult Created_project()
        {
            using (ProjectContext pc=new ProjectContext()) {
                List <CreateProject>projects = pc.CreatedProject.Where(s => s.FacultyId == User.Identity.Name).ToList();
                return View(projects);
            } 

                
        }

        public ActionResult Details(int id)
        {
            using (ProjectContext pc=new ProjectContext()) {
                CreateProject project=pc.CreatedProject.FirstOrDefault(s => s.Pid == id);
                return View(project);
            }
                
        }

        public ActionResult Edit(int id) {

            using (ProjectContext pc = new ProjectContext())
            {
                CreateProject project = pc.CreatedProject.FirstOrDefault(s => s.Pid == id);
                return View(project);
            }
        }

        [HttpPost]
        public ActionResult Edit(CreateProject p) {
            using (ProjectContext pc=new ProjectContext()) {

                CreateProject cp = pc.CreatedProject.FirstOrDefault(x=>x.Pid==p.Pid);
                cp.Pdef = p.Pdef;
                cp.Pdesp = p.Pdesp;
                cp.Psem = p.Psem;
                cp.Psub = p.Psub;
                cp.SelectionDeadline = p.SelectionDeadline;
                cp.SubmissionDeadline = p.SubmissionDeadline;
                cp.totalMarks = p.totalMarks;
                cp.PTarYear = p.PTarYear;

                pc.SaveChanges();
            }
                return Redirect("~/Faculty/Created_project");

        }
        public ActionResult Delete(int id) {
            using (ProjectContext pc=new ProjectContext()) {
               CreateProject cp= pc.CreatedProject.FirstOrDefault(x=>x.Pid==id);
                pc.CreatedProject.Remove(cp);
                pc.SaveChanges();
                return Redirect("~/Faculty/Created_project");

            }

        }
        //View Selection for faculty
        public ActionResult view_teams(int id)
        {
            using (ProjectContext pc = new ProjectContext())
            {
                List<ActiveProject> ap = pc.ActiveProject.Where(x => x.Pid == id).ToList();
                //uploaded team
               
                return View(ap);
            }
               
        }
        public ActionResult upload_marks(int id)
        {


            using (ProjectContext pc = new ProjectContext())
            {
                ActiveProject ap = pc.ActiveProject.FirstOrDefault(x => x.ActId == id);
                TempData["teamdata"] = ap;
                return View(ap);
            }
        }
        [HttpPost]
        public ActionResult upload_marks(int mem1_marks, int mem2_marks, int mem3_marks,string remarks)
        {
            ActiveProject ap = (ActiveProject)TempData["teamdata"];
            using (ProjectContext pc=new ProjectContext()) {
                ProjectEvaluation pe = new ProjectEvaluation();
                pe.mem1_marks = mem1_marks;
                pe.mem2_marks = mem2_marks;
                pe.mem3_marks = mem3_marks;
                pe.member1_id = ap.member1_id;
                pe.member2_id = ap.member2_id;
                pe.member3_id = ap.member3_id;
                pe.Remarks = remarks;
                pe.Pid = ap.Pid;
                pe.totmarks = pc.CreatedProject.FirstOrDefault(x => x.Pid == ap.Pid).totalMarks;
                System.Diagnostics.Debug.WriteLine(pe.mem3_marks+pe.mem1_marks+pe.mem2_marks+"  "+remarks+pe.member1_id+pe.member2_id+pe.member3_id);
                pc.ProjectEvaluation.Add(pe);
              //  pc.ActiveProject.Remove(pc.ActiveProject.FirstOrDefault(x => x.ActId == ap.ActId));

                pc.SaveChanges();

            }
                return Redirect("~/Faculty/Index");
        }

        public ActionResult download_project(int id)
        {
            using (ProjectContext pc  = new ProjectContext())
            {
                ActiveProject ap=pc.ActiveProject.FirstOrDefault(x=>x.ActId==id);
                try
                {
                    SubmittedProject sp = pc.SubmittedProject.FirstOrDefault(x => x.Pid == ap.Pid && (x.member1_id == ap.member1_id || x.member1_id == ap.member2_id || x.member1_id == ap.member3_id));
                    string full_path = sp.ProjectFile;

                    System.Diagnostics.Debug.WriteLine(full_path);
                    return File(full_path, "application/zip", Path.GetFileName(full_path));
                }
                catch (Exception e) {
                    return View();
                }
                

            }
        }

        public ActionResult Created_project_list()
        {
            using (ProjectContext pc = new ProjectContext())
            {
                List<CreateProject> projects = pc.CreatedProject.Where(s => s.FacultyId == User.Identity.Name).ToList();
                return View(projects);
            }


        }
        public ActionResult marks(int id) {

            using (ProjectContext pc=new ProjectContext()) {
                List<ProjectEvaluation> pe = pc.ProjectEvaluation.Where(x => x.Pid == id).ToList();
                return View(pe);

            }

        }


    }
}