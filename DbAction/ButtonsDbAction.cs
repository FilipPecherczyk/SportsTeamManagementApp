using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.STMApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.DbAction
{
    public class ButtonsDbAction
    {
        public static void AddButton(string buttonJson)
        {
            using (var db = new DatabaseContext())
            {
                db.Buttons.Add(new ButtonsDomain()
                {
                    ButtonsJSON = buttonJson,
                    TeamId = STMAppMainData.LogedUserTeam.Id,
                });
                db.SaveChanges();
            }
        }

        public static void SaveEditButtons(string buttonJson, int id)
        {
            using (var db = new DatabaseContext())
            {
                var existingButtons = db.Buttons.FirstOrDefault(b => b.Id == id);

                if (existingButtons != null)
                {
                    existingButtons.ButtonsJSON = buttonJson;

                    db.SaveChanges();
                }
            }
        }

        public static ButtonsDomain GetButtons()
        {
            using (var db = new DatabaseContext())
            {
                return db.Buttons.Where(b => b.TeamId == STMAppMainData.LogedUserTeam.Id).OrderBy(b => b.Id).FirstOrDefault();
            }
        }
    }
}
