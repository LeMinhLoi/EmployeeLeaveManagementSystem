using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.ApplicationLayer.Contracts;
using Project.ApplicationLayer.ViewModels.LeaveTypes;
using Project.Data.Entities;

namespace Project.Web.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;
        private readonly IMapper _mapper;
        public LeaveTypeController(ILeaveTypeService leaveTypeService, IMapper mapper)
        {
            _leaveTypeService = leaveTypeService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("leavetype/get-paging")]
        public async Task<IActionResult> GetLeaveTypesAsync()
        {
            try
            {
                //var draw = Request.Form["draw"].FirstOrDefault();
                //var start = Request.Form["start"].FirstOrDefault();
                //var length = Request.Form["length"].FirstOrDefault();
                //var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                //var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                //var searchValue = Request.Form["search[value]"].FirstOrDefault();
                //int pageSize = length != null ? Convert.ToInt32(length) : 0;
                //int skip = start != null ? Convert.ToInt32(start) : 0;
                //int recordsTotal = 0;
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.FirstName.Contains(searchValue)
                //                                || m.LastName.Contains(searchValue)
                //                                || m.Contact.Contains(searchValue)
                //                                || m.Email.Contains(searchValue));
                //}
                //recordsTotal = customerData.Count();
                //var data = customerData.Skip(skip).Take(pageSize).ToList();
                //var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                //return Ok(jsonData);
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                var pagination = new LeaveTypePagingRequest()

                {
                    PageSize = pageSize,
                    StartPage = skip + 1,
                    SearchValue = searchValue,
                    SortColumn = sortColumn,
                    TypeSort = sortColumnDirection
                };
                var objectReturn = await _leaveTypeService.GetPagingAsync(pagination);
                var jsonData = new { draw = draw, recordsFiltered = objectReturn.RecordsFiltered, recordsTotal = objectReturn.RecordsTotal, data = objectReturn.LeaveTypeListVMs };
                return new OkObjectResult(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _leaveTypeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(LeaveTypeCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(request);
                await _leaveTypeService.AddAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: LeaveType/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var leaveType = await _leaveTypeService.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeVM = _mapper.Map<LeaveTypeUpdateRequest>(leaveType);
            return View(leaveTypeVM);
        }


        //tại sao id lại để riêng ra như thế này => vì có thể ai đó hack được tham số request và thay đổi id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, LeaveTypeUpdateRequest request)
        {
            if (id != request.Id)
            {
                return View(request);
            }

            var leaveType = await _leaveTypeService.GetAsync(id);

            if (leaveType == null)
            {
                return View(request);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _mapper.Map(request, leaveType);
                    await _leaveTypeService.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(request);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        [HttpGet("leavetype/get-detail")]
        public async Task<IActionResult> Details(Guid id)
        {
            return Ok(_mapper.Map<LeaveTypeDetail>(await _leaveTypeService.GetAsync(id)));
        }
    }
}
