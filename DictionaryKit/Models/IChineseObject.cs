using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryKit.Models
{
    public interface IChineseObject
    {
        string GetSearchContent(bool isStrict);
    }
}
