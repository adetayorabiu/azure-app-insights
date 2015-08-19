//
// Copyright (C) Microsoft Corporation.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Data.Entity;
using System.Data.Entity.SqlServer;
using MyFixIt.Common.Models;

namespace MyFixIt.Persistence
{
    internal class MyFixItContext : DbContext
    {
        static MyFixItContext()
        {
            DbConfiguration.SetConfiguration(new EFConfiguration());
        }

        public MyFixItContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<FixItTask> FixItTasks { get; set; }
    }

    // EF follows a Code based Configration model and will look for a class that
    // derives from DbConfiguration for executing any Connection Resiliency strategies
    internal class EFConfiguration : DbConfiguration
    {
        public EFConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}