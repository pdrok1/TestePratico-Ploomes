using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetMessagesWithTitle
{
    public class GetMessagesWithTitleCommandRequest : IRequest<GetMessagesWithTitleCommandResponse>
    {
        public string TitleQuery { get; set; }

        public GetMessagesWithTitleCommandRequest(string titleQuery)
        {
            TitleQuery = titleQuery;
        }
    }
}
