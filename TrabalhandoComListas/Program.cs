using TrabalhandoComListas;
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

listaDoBancoDeDados.Where(re => 
                    !listaDoFrontEnd.Any(a => a.Id == re.Id))
                    .ToList()
                    .ForEach(r=> listaDoBancoDeDados.Remove(r));
Console.WriteLine("\n***-Lista do banco após a remoção de itens que não existem na lista do Frontend-***\n");
foreach (var atividade in listaDoBancoDeDados)
{
    
    Console.WriteLine(atividade.ToString());
}

var listaParaRemover = listaDoBancoDeDados.Where(at => !listaDoFrontEnd.Any(a => a.Id == at.Id && a.Descricao == at.Descricao)).ToList();
listaParaRemover.ForEach(atividade => listaDoBancoDeDados.Remove(atividade));

Console.WriteLine("\n****-Lista do banco após remover itens que estão diferentes-****\n");
foreach (var atividade in listaDoBancoDeDados)
{    
    Console.WriteLine(atividade.ToString());
}

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
listaDoBancoDeDados.AddRange(novasAtividades);
Console.WriteLine("\n****-Lista do Banco de Dados atualizado, contendo itens atualizados e alterados-****\n");

foreach (var atividade in listaDoBancoDeDados)
{
    Console.WriteLine(atividade.ToString());
}





