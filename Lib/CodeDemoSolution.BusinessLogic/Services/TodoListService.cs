namespace CodeDemoSolution.BusinessLogic.Services
{
    using DataAccess.Interfaces.UnitOfWork;
    using Model;
    using Model.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TodoListService
    {
        private ITodoUnitOfWork UnitOfWork { get; set; }

        public TodoListService(ITodoUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public TodoListSaveResult CreateNewTodoList(TodoList todoList)
        {
            TodoListSaveResult saveResult = TodoListSaveResult.OtherError;

            if (todoList == null)
            {
                saveResult = TodoListSaveResult.NoRecordToSave;
            }

            if (string.IsNullOrEmpty(todoList.Title))
            {
                saveResult = TodoListSaveResult.MissingTitle;
            }

            if (string.IsNullOrEmpty(todoList.Description))
            {
                saveResult = TodoListSaveResult.MissingDescription;
            }

            try
            {
                todoList = this.UnitOfWork.TodoListRepository.Add(todoList);

                this.UnitOfWork.Save();

                if (todoList.Id > 0)
                {
                    saveResult = TodoListSaveResult.Saved;
                }
            }
            catch (Exception)
            {
                // Log the exception
                saveResult = TodoListSaveResult.OtherError;
            }

            return saveResult;
        }

        public TodoList GetTodoListById(int itemId)
        {
            try
            {
                if (itemId <= 0)
                {
                    throw new ArgumentException("itemId must be above zero");
                }

                return this.UnitOfWork.TodoListRepository.GetById(itemId);
            }
            catch (Exception)
            {
                // Log the exception
                return null;
            }
        }

        public List<TodoList> GetTodoLists(int skip = 0, int take = 0)
        {
            List<TodoList> results = null;

            try
            {
                var lazyResult = UnitOfWork.TodoListRepository.All;

                if (skip > 0)
                {
                    lazyResult = lazyResult.Skip(skip);
                }

                if (take > 0)
                {
                    lazyResult = lazyResult.Take(take);
                }

                results = lazyResult.ToList();
            }
            catch (Exception)
            {
                // Log exception
            }

            return results;
        }

        public int GetTodoListCount()
        {
            int todoListCount = 0;

            try
            {
                 todoListCount = UnitOfWork.TodoListRepository.All.Count();
            }
            catch (Exception)
            {
                // Log exception
            }

            return todoListCount;
        }
    }
}
