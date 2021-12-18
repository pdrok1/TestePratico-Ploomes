using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetMessagesContainingInTitle
{
    public class GetMessagesContainingTitleCommandRequest : IRequest<GetMessagesContainingTitleCommandResponse>
    {
        public string TitleQuery { get; set; }

        public GetMessagesContainingTitleCommandRequest(string titleQuery)
        {
            TitleQuery = titleQuery;
        }
    }
}
