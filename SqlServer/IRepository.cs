using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlServer
{
    interface IRepository
    {
    }

    public class TestService
    {
        
        public TestService()
        {
            var _repository = new DevOnlyEntities();
            Repository = _repository;
        }

        public DevOnlyEntities Repository;

    }
}


