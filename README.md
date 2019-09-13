# Projeto Auto Coder.

Projeto pensado para agilizar a automatização de páginas novas no MIB. No momento da automatização dessas novas páginas, muitos pontos do processo são
extremamente parecidos, por isso, eles podem ser automatizados.

O Auto Coder também gera automaticamente alguns testes. Os seguintes testes estão sendo gerados atualmente:

 - OpenEdit
 - OpenList
 
## O que o projeto automatiza:

Quando vamos começar a automatização de uma nova classe, seguimos o padrão Page Object: https://www.automatetheplanet.com/page-object-pattern/ . Em casos normais, são necessárias quatro classes para começar podermos efetivamente rodar os testes, sendo elas:
 * PageEditPageFields
 * PageEditPage
 * PageListPage
 * PageTests
	
O Auto coder irá gerar essas classes quando utilizado
	
## O que o projeto não automatiza:

No MIB há algumas páginas que não seguem o mesmo padrão das outras, elas são chamadas custom pages. O projeto não automatiza essas páginas. Algumas páginas que não seguem esse padrão são:
 * Content Purge
 * Parameters
 * Catalog Exporter
	
## Como o projeto funciona:
	
O processo de procurar o ID dos campos da página tem que ser feito manualmente. Após o usuário encontrar os Ids dos campos, é necessário preencher um Json com as seguintes informações de todos os campos:
 * Nome do campo
 * Tipo da propriedade que será criada 
 * Id do campo
 * Data Field Type do campo
	
E um Json com informações da página. As informações são:
 * Nome da classe a ser criada
 * Menu da página
 * Chave do componente
	
Há Jsons de exemplo no diretório Input example, Caminho GVP-QA>gvp-qa-auto-coder > Input examples
	
O diretório onde os json precisam ser colocados para o programa encontra-los é no seguinte caminho ..\GVP-QA\gvp-qa-auto-coder\gvp-qa-auto-coder\bin\Input-Jsons
	Quando o programa for gerar as classes, ele criará, caso ainda não exista, um diretório chamado Output-Jsons no mesmo diretório do Input-Jsons. Após a criação dos arquivos,
	basta entrar no visual studio criar as pastas conforme o padrão do caminho no MIB, clicar com o botão direito na pasta onde as classes irão ficar > add existing e selecionar as classes
	
