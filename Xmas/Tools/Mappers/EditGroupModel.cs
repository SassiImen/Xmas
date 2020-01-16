using System.Collections.Generic;
using Xmas.Areas.Membre.Models;

namespace Xmas.Tools.Mappers
{
    public class EditGroupModel
    {
        public GroupModel MonGroupe { get; internal set; }
        public List<EventModel> MesEvents { get; internal set; }
    }
}