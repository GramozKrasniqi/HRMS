using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
using DAL.Mapper;

namespace HRM
{
    public static class Authorization
    {
        public static RoleEntity isAuthorized(string username, string formPath)
        {
            if (formPath.Contains("?"))
            {
                formPath = formPath.Substring(0 ,formPath.IndexOf("?"));
            }

            List<RoleEntity> roles = new RoleMapper().GetRoleForUser(username);

            foreach (RoleEntity role in roles)
            {
                if (new RoleMapper().RoleCanViewForm(role.Id, formPath))
                {
                    return roles[0];
                }
            }

            return null;
        }
    }
}