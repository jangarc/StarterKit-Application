using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Security;

public interface ITokenService
{
    string GenerateJwtToken(string account, string userName, string role);
}
