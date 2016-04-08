namespace CodeDemoSolution.BusinessLogic.Services
{
    using DataAccess.Interfaces.UnitOfWork;
    using Model;
    using Model.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TodoItemService
    {
        private ITodoUnitOfWork UnitOfWork { get; set; }

        public TodoItemService(ITodoUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public TodoItemSaveResult CreateNewTodoList(TodoItem todoItem)
        {
            TodoItemSaveResult saveResult = TodoItemSaveResult.OtherError;

            if (todoItem == null)
            {
                saveResult = TodoItemSaveResult.NoTodoListKnown;
            }

            if (todoItem.TodoListId <= 0)
            {
                saveResult = TodoItemSaveResult.NoTodoListKnown;
            }

            if (string.IsNullOrEmpty(todoItem.Title))
            {
                saveResult = TodoItemSaveResult.MissingTitle;
            }

            if (string.IsNullOrEmpty(todoItem.Body))
            {
                saveResult = TodoItemSaveResult.MissingMessage;
            }

            try
            {
                if (this.UnitOfWork.TodoListRepository.GetById(todoItem.TodoListId) != null)
                {
                    todoItem = this.UnitOfWork.TodoItemRepository.Add(todoItem);


                    if (todoItem.Id > 0)
                    {
                        saveResult = TodoItemSaveResult.Saved;
                        this.UnitOfWork.Save();
                    }
                }
                else
                {
                    saveResult = TodoItemSaveResult.TodoListNotFound;
                }
            }
            catch (Exception)
            {
                // Log the exception
                saveResult = TodoItemSaveResult.OtherError;
            }

            return saveResult;
        }

        public TodoItem GetTodoItemById(int itemId)
        {
            try
            {
                if (itemId <= 0)
                {
                    throw new ArgumentException("itemId must be above zero");
                }

                return this.UnitOfWork.TodoItemRepository.GetById(itemId);
            }
            catch (Exception)
            {
                // Log the exception
                return null;
            }
        }

        public List<TodoItem> GetTodoItemsForList(int todoListId, int skip = 0, int take = 0)
        {
            List<TodoItem> results = null;

            try
            {
                var lazyResult = UnitOfWork.TodoItemRepository.All.Where(x => x.TodoListId == todoListId);

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

        public int GetTodoItemCountForList(int todoListId)
        {
            int todoItemCount = 0;

            try
            {
                todoItemCount = UnitOfWork.TodoItemRepository.All.Where(x => x.TodoListId == todoListId).Count();
            }
            catch (Exception)
            {
                // Log exception
            }

            return todoItemCount;
        }
    }
}
