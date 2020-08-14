﻿using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Id { get; private set; }

        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
                return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
          var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType FindById(int Id)
        {
            var leaveType = _db.LeaveTypes.Find(Id);
            return leaveType;
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int Id)
        {
            throw new NotImplementedException();
        }


        public bool isExists(object id)
        {
            var exists = _db.LeaveTypes.Any(q => q.Id == Id);
            return exists;
        }

        public bool isExists(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
