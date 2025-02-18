using System;
using System.Collections.Generic;

class Program {
  static List<TaskItem> tasks = new List<TaskItem>();
  static int nextId = 1;

  static void Main(string[] args) {
    Console.WriteLine("Bem-Vindo ao Gerenciador de Tarefas!");

    while (true) {
      Console.WriteLine("Escolha uma opção:");
      Console.WriteLine("1 - Adicionar Tarefa");
      Console.WriteLine("2 - Listar Tarefas");
      Console.WriteLine("3 - Concluir Tarefa");
      Console.WriteLine("4 - Excluir Tarefa");
      Console.WriteLine("5 - Sair");

      string choice = Console.ReadLine();

      switch (choice) {
        case "1":
          AddTask();
          break;
        case "2":
          ListTasks();
          break;
        case "3":
          CompleteTask();
          break;
        case "4":
          DeleteTask();
          break;
        case "5":
          Console.WriteLine("Obrigado por usar o Gerenciador de Tarefas!");
          return;
        default:
          Console.WriteLine("Opção inválida. Tente novamente.");
          break;
      }
    }
  }

  static void AddTask() {
    Console.WriteLine("Digite a descrição da tarefa:");
    string description = Console.ReadLine();

    tasks.Add(new TaskItem { Id = nextId, Description = description, IsDone = false });

    Console.WriteLine("Tarefa adicionada com sucesso!");
  }

  static void ListTasks() {
    if (tasks.Count == 0) {
      Console.WriteLine("Nenhuma tarefa encontrada.");
      return;
    }

    Console.WriteLine("Tarefas:");
    foreach (var task in tasks) {
      Console.WriteLine($"ID: {task.Id}, Descrição: {task.Description}, Concluída: {task.IsDone}");
    }
  }

  static void CompleteTask() {
    Console.WriteLine("Digite o ID da tarefa a ser concluída:");
    int taskId = int.Parse(Console.ReadLine());

    var task = tasks.Find(t => t.Id == taskId);
    if (task != null) {
      task.IsDone = true;
      Console.WriteLine("Tarefa concluída com sucesso!");
    } else {
      Console.WriteLine("Tarefa não encontrada.");
    }
  }

  static void DeleteTask() {
    Console.WriteLine("Digite o ID da tarefa a ser excluída:");
    int taskId = int.Parse(Console.ReadLine());

    var task = tasks.Find(t => t.Id == taskId);
    if (task != null) {
      tasks.Remove(task);
      Console.WriteLine("Tarefa excluída com sucesso!");
    } else {
      Console.WriteLine("Tarefa não encontrada.");
    }
  }
}

