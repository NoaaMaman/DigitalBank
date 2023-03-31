using Bankproject.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankproject.Common.Dtos;

public record AccountGet(string FirstName,
                            string LastName,
                            string AccountName,
                            string PhoneNumber,
                            string Email,
                            decimal CurrentAccountBalance,
                            AccountType AccountType,
                            string AccountNumberGenerated,
                            byte[] PinHas,
                            DateTime DateCreated,
                            DateTime DateLastUpdated);
