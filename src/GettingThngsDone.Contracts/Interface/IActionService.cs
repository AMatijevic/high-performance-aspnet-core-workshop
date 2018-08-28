﻿using GettingThingsDone.Contract.Dto;
using System.Collections.Generic;

namespace GettingThingsDone.Contract.Interface
{
    public interface IActionService
    {
        ActionDto GetAction(int id);
        List<ActionDto> GetTop(int count);
        ActionDto CreateOrUpdate(int? id, ActionDto actionDto);
        DataActionResultDto Delete(int id);
        DataActionResultDto MoveToList(int id, int listId);
        DataActionResultDto AssignToProject(int id, int projectId);
    }
}