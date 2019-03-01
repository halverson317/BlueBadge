using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class DrinkerService
    {
        private readonly Guid _userID;

        public DrinkerService (Guid userID)
        {
            _userID = userID;
        }

        //    public DrinkerDetailDTO GetDetailInfo()
        //    {
        //        using (var ctx = new ApplicationDbContext())
        //        {
        //            GroupEntity group;
        //            var groupMember = ctx.GroupMembers.FirstOrDefault(g => g.MemberId == _userId);

        //            if (groupMember == null)
        //                group = ctx.Groups.FirstOrDefault(g => g.OwnerId == _userId);
        //            else
        //                group = groupMember.Group;

        //            if (group != null)
        //            {
        //                var owner = ctx.Users.FirstOrDefault(u => u.Id == group.OwnerId.ToString());
        //                return new GroupDetailDTO
        //                {
        //                    GroupId = group.GroupId,
        //                    GroupName = group.GroupName,
        //                    GroupInviteKey = group.GroupInviteKey,
        //                    GroupOwner = owner.UserName
        //                };
        //            }

        //            return new GroupDetailDTO();
        //        }
        //    }

        //    public List<GroupMemberDetailDTO> GetApplicants(int groupId)
        //    {
        //        using (var ctx = new ApplicationDbContext())
        //        {
        //            var members = new List<GroupMemberDetailDTO>();
        //            var groupMembers = ctx.GroupMembers.Where(g => g.GroupId == groupId && g.InGroup == false);

        //            foreach (var gm in groupMembers)
        //            {
        //                var member = ctx.Users.Single(u => u.Id == gm.MemberId.ToString());
        //                members.Add(new GroupMemberDetailDTO
        //                {
        //                    UserName = member.UserName
        //                });
        //            }

        //            return members;
        //        }
        //    }

        //    public List<GroupMemberDetailDTO> GetGroupMembers(int groupId)
        //    {
        //        using (var ctx = new ApplicationDbContext())
        //        {
        //            var members = new List<GroupMemberDetailDTO>();
        //            var groupMembers = ctx.GroupMembers.Where(g => g.GroupId == groupId && g.InGroup == true);

        //            foreach (var gm in groupMembers)
        //            {
        //                var member = ctx.Users.Single(u => u.Id == gm.MemberId.ToString());
        //                members.Add(new GroupMemberDetailDTO
        //                {
        //                    UserName = member.UserName
        //                });
        //            }

        //            return members;
        //        }
        //    }

        //
    }
}
