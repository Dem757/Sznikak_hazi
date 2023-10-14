using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernLangToolsApp
{
    public delegate void CouncilChangedDelegate(string message);

    public class JediCouncil
    {
        public event CouncilChangedDelegate CouncilChanged;

        List<Jedi> members = new List<Jedi>();

        public void Add(Jedi newJedi)
        {
            members.Add(newJedi);

            CouncilChanged?.Invoke("Új taggal bővültünk\r\n");
        }

        public void Remove()
        {
            // Eltávolítja a lista utolsó elemét
            members.RemoveAt(members.Count - 1);

            CouncilChanged?.Invoke(members.Count >= 1 ? "A tanács elesett!\r\n" : "Zavart érzek az erőben\r\n");
        }

        public List<Jedi> WeakJedis_Delegate()
        {
            return members.FindAll(WeakJedi);
        }

        public bool WeakJedi(Jedi j)
        {
            return j.MidiChlorianCount < 530;
        }

        public List<Jedi> NotThatWeakJedis_Lambda() 
        {
            return members.FindAll(jedi => jedi.MidiChlorianCount < 1000);
        }
    }
}
