using TrabalhandoComListas;

//Links utilizados para estudo
//O que é o Enumerable.Where Método https://learn.microsoft.com/pt-br/dotnet/api/system.linq.enumerable.where?view=net-8.0
//O que é o Enumerable.Any Método : https://learn.microsoft.com/pt-br/dotnet/api/system.linq.enumerable.any?view=net-8.0
//O que é o Enumerable.Select Método: https://learn.microsoft.com/pt-br/dotnet/api/system.linq.enumerable.select?view=net-8.0
var listaDoFrontEnd = new List<Atividade>() {
new Atividade(){Id=1,Descricao="Construção", DataCriacao=DateTime.Now },
new Atividade(){Id=2,Descricao="Varejo Alterada", DataCriacao=DateTime.Now},
new Atividade(){Id=3,Descricao="Manutenção Predial", DataCriacao=DateTime.Now},
new Atividade(){Id=13,Descricao="Atividade Adicionada", DataCriacao=DateTime.Now},
};

var listaDoBancoDeDados = new List<Atividade>()
{
new Atividade(){Id=1,Descricao="Construcao", DataCriacao=DateTime.Now },
new Atividade(){Id=2,Descricao="Varejo", DataCriacao=DateTime.Now},
new Atividade(){Id=3,Descricao="Manutenção Predial", DataCriacao=DateTime.Now},
new Atividade(){Id=4,Descricao="Seriços Eletrônicos", DataCriacao=DateTime.Now}
};

Console.WriteLine("\n***-Lista que recebemos na requisição vinda do Frontend***\n");
foreach (var atividade in listaDoFrontEnd)
{
    Console.WriteLine(atividade.ToString());
}


Console.WriteLine("\n***-Lista que buscaremos no Banco de Dados***\n");
foreach (var atividade in listaDoBancoDeDados)
{
    Console.WriteLine(atividade.ToString());
}
//Aqui removemos do banco de dados os itens que não existem mais na lista atual que veio do Frontend.
//Dentro do metodo ForEach utilize o seu repository.dbSet.Remove(a)
//at é atividade do banco de dados que vamos verificar se existe na lista que veio do front
//os itens que nao existirem na lista do banco de dados serão removidos. 
listaDoBancoDeDados.Where(at => 
                    !listaDoFrontEnd.Any(a => a.Id == at.Id))
                    .ToList()
                    .ForEach(a=> listaDoBancoDeDados.Remove(a));
Console.WriteLine("\n***-Lista do banco após a remoção de itens que não existem na lista do Frontend-***\n");
foreach (var atividade in listaDoBancoDeDados)
{
    
    Console.WriteLine(atividade.ToString());
}

//Aqui vamos remover do banco de dados os itens que existem mas que estão diferentes e que precisam ser atualizados.
var listaParaRemover = listaDoBancoDeDados.Where(at => 
                                            !listaDoFrontEnd.Any(a => a.Id == at.Id && a.Descricao == at.Descricao))
                                            .ToList();
/*Aqui estou percorrendo a lista de itens que precisam ser removidos do banco de dados,
 no caso utilize RemoveRange do repository.dbSet.RemoveRange(listaParaRemover)
*/
listaParaRemover.ForEach(atividade => listaDoBancoDeDados.Remove(atividade));

Console.WriteLine("\n****-Lista do banco após remover itens que estão diferentes-****\n");
foreach (var atividade in listaDoBancoDeDados)
{    
    Console.WriteLine(atividade.ToString());
}

//Aqui vamos serpar os itens que precisam ser inseridos novamente no Banco de Dados, tanto os novos itens quanto os que
//sofreram alterações.
var novasAtividades = listaDoFrontEnd.Where(atf=> !listaDoBancoDeDados.Any(atb=> atb.Id==atf.Id && atb.Descricao==atf.Descricao))
    .Select(a=> new Atividade
    {
        Id = a.Id,
        Descricao=a.Descricao,
        DataCriacao=DateTime.Now
    });
Console.WriteLine("\n****-Lista de novas Atividades e Atividades que sofreram alterações-****\n");
foreach (var atividade in novasAtividades)
{
    Console.WriteLine(atividade.ToString());
}
//Aqui estamos adicionando as novas atividades e as atividades que foram atualizadas.
listaDoBancoDeDados.AddRange(novasAtividades);
Console.WriteLine("\n****-Lista do Banco de Dados atualizado, contendo itens atualizados e alterados-****\n");

foreach (var atividade in listaDoBancoDeDados)
{
    Console.WriteLine(atividade.ToString());
}





