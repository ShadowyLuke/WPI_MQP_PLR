//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PostLectureReview.Models;
//using PostLectureReview.Models.Structure;

//namespace PostLectureReview.Controllers
//{
//    public class LecturesController : Controller
//    {
//        private readonly DevelopmentContext _context;

//        public LecturesController(DevelopmentContext context)
//        {
//            _context = context;
//        }

//        // GET: Lectures
//        public IActionResult Test()
//        {
//            return View();
//        }

//        // GET: Lectures
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Lecture.ToListAsync());
//        }

//        // GET: Lectures/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var lecture = await _context.Lecture
//                .SingleOrDefaultAsync(m => m.ID == id);
//            if (lecture == null)
//            {
//                return NotFound();
//            }

//            return View(lecture);
//        }

//        // GET: Lectures/Create
//        public IActionResult Create()
//        {
//            var lecture = new Lecture();
//            lecture.AddTopics(2);
//            lecture.AddQuestions(2);
//            return View(lecture);
//        }

//        [HttpPost]
//        public ActionResult Create(Lecture lecture)
//        {
//            // TODO
//            return Redirect("Create");
//        }
//        // POST: Lectures/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> Create([Bind("ID,Date,Code,Title,URLCode")] Lecture lecture)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        _context.Add(lecture);
//        //        await _context.SaveChangesAsync();
//        //        return RedirectToAction(nameof(Index));
//        //    }
//        //    return View(lecture);
//        //}

//        // GET: Lectures/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }
//            var lecture = await _context.Lecture.SingleOrDefaultAsync(m => m.ID == id);
//            if (lecture == null)
//            {
//                return NotFound();
//            }
//            return View(lecture);
//        }

//        // POST: Lectures/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Code,Title,URLCode")] Lecture lecture)
//        {
//            if (id != lecture.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(lecture);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!LectureExists(lecture.ID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(lecture);
//        }

//        // GET: Lectures/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var lecture = await _context.Lecture
//                .SingleOrDefaultAsync(m => m.ID == id);
//            if (lecture == null)
//            {
//                return NotFound();
//            }

//            return View(lecture);
//        }

//        // POST: Lectures/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var lecture = await _context.Lecture.SingleOrDefaultAsync(m => m.ID == id);
//            _context.Lecture.Remove(lecture);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool LectureExists(int id)
//        {
//            return _context.Lecture.Any(e => e.ID == id);
//        }
//    }
//}
