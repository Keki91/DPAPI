using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DPAPI.Context
{
    public class KeysContext : DbContext, IDataProtectionKeyContext
    {
        public KeysContext(DbContextOptions<KeysContext> options) : base(options)
        {

        }

        public virtual DbSet<DataProtectionKey> DataProtectionKeys { get; set;  }
    }
}
