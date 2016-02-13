using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextRecognizer
{
    public class ContextHelper
    {
        public List<SensiumResultPhrase> FilterWordsWithoutInformation(List<SensiumResultPhrase> phrases)
        {
            List<SensiumResultPhrase> toreturn = new List<SensiumResultPhrase>();

            foreach(SensiumResultPhrase phrase in phrases)
            {
                if(!phrase.Text.ToLower().Equals("und") &&
                   !phrase.Text.ToLower().Equals("posteingang") &&
                   !phrase.Text.ToLower().Equals("untitled") &&
                   !phrase.Text.ToLower().Equals("dokument1") &&
                   !phrase.Text.ToLower().Equals("running") &&
                   !phrase.Text.ToLower().Contains("visual studio"))
                {
                    toreturn.Add(phrase);
                }
            }

            //now remove duplicates
            List<SensiumResultPhrase> noDuplicates = new List<SensiumResultPhrase>();

            foreach(SensiumResultPhrase phr in toreturn)
            {
                bool found = false;

                foreach(SensiumResultPhrase p in toreturn)
                {
                    if(!p.Equals(phr))
                    {
                        if(p.Text.ToLower() == phr.Text.ToLower())
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if(found == false)
                {
                    noDuplicates.Add(phr);
                }
            }



            return noDuplicates;
        }
    }
}
