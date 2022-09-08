## API dos serviços da plataforma digital única
Descreve a especificação da API relativa à partilha de estatísticas sobre os utilizadores e reações sobre os serviços da plataforma digital única em conformidade com o Regulamento (UE) 2018/1724 do Parlamento Europeu e do Conselho

Existem cinco APIS no âmbito deste projecto para tranferir dados  da ferramenta comum ou das ferramentas comuns dos estados membros para processamento, análise e visualização.



# 1. API para o identificador único
Esta API tem o objetivo de gerar um ID único para ser usado para chamar as outras APIS no envio de informação estatística ou de retorno de informação para um intervalo de referência.
Amtes de invocar as restantes APIS devemos invocar esta API para gerar o número único primeiro.


 O ID único recebido na resposta vai ser utilizdo para chamar as outras API's e quando forem invocadas as restantes APIS devemos ter conta os seguintes pontos:
 - Um intervalo de referência corresponde a um ID único
 - A entidade competente deve manter um mapeamento entre o ID único e o intervalo de referência que foi utilizado
 - Se alguma das APIS for invocada para reenviar os dados de um intervalo de referência  devemos usar um ID único e não voltar a chamar a API de identificador único.
 - Se a entidade necessitar de alterar informamção já enviada para um intervalo de referência, deve usar o mesmo identificador único.
 - A informação que for reenviada com o mesmo ID único vai ser sobreposta.
 
 Exemplo de resposta:
```markdown
 {"unique-id": "838a89cd-f096-4847-be3f-a053ef9749bf"}
```
[Consultar o swagger](uniqueId.html)



# 2. Estatísticas de serviços informativos
Esta API serve para transferir dados estatítisticos nos serviços informativos para um  período de tempo .
A frequência de envio deve ser mensal. Não é possível enviar múltiplos intervalos de referência numa vez.
Esta API não permite enviar mensagens com tamanho superior a 10 mb , no caso disso acontecer os intervalos de referência devem ser dividos para respeitar o limite.
O pedido e a resposta estão explicados na tabela abaixo.


- Número de visitas
- Países dos utilizadores que visitam as páginas web
- Dispositivos utilizados para visitar as páginas web
- Dados de contexto
- Frequência uma vez por mês


<table>
  <tr>
    <th colspan="4">Pedido</th>  
  </tr>
  <tr>
    <th>Parâmetros</th>
    <th>Tipo</th>
    <th>Obrigatório (Sim/ Não)</th>
    <th>Comentários</th>
  </tr>
  <tr>
    <td>isSDG</td>
    <td>boolean</td>
    <td>Sim</td>
    <td>A informação enviada está a ser enviada no âmbito do SDG?</td>
  </tr>
  <tr>
    <td>informationServiceStats</td>
    <td>Object</td>
    <td>Sim</td>
    <td>O objeto que representa os serviços informativos</td>
  </tr>
  <tr>
    <td>uniqueId</td>
    <td>string</td>
    <td>Sim</td>
    <td> O identificador único para o envio das estatísticas dos  serviços informativos para um intervalo de referência específico que é obtido através da api de Identificador Único</td>
  </tr>
  <tr>
    <td>referencePeriod</td>
    <td>Object</td>
    <td>Sim</td>
    <td>Representação do intervalo de referência com a data de ínicio e de fim.</td>
  </tr>
  <tr>
    <td>startDate</td>
    <td>string</td>
    <td>Sim</td>
    <td>Data de ínicio do intervalo de referência</td>
  </tr>
  <tr>
    <td>endDate</td>
    <td>string</td>
    <td>Sim</td>
    <td>Data de fim do intervalo de referência</td>
  </tr>
  <tr>
    <td>transferDate</td>
    <td>string</td>
    <td>Sim</td>
    <td>Data e hora em que estamos a invocar a API</td>
  </tr>
  <tr>
    <td>transferType</td>
    <td>String (enum)</td>
    <td>Sim</td>
    <td>Tipo de transferência de dados, neste caso será "API"</td>
  </tr>
  <tr>
    <td>nbEntries</td>
    <td>integer</td>
    <td>Sim</td>
    <td>Número de entradas , incluindo todas as fontes de URL's para as estatísticas que estão a ser enviadas</td>
  </tr>
  <tr>
    <td>sources</td>
    <td>Array of Objects</td>
    <td>Sim</td>
    <td>Representação da informação estatística sobre uma URL . Um objeto pode referenciar vários URLs</td>
  </tr>
  <tr>
    <td>source</td>
    <td>object</td>
    <td>Sim</td>
    <td>Dados estatísticos</td>
  </tr>
  <tr>
    <td>sourceUrl</td>
    <td>string</td>
    <td>Sim</td>
    <td>URL através do qual os dados estão a ser obtidos.</td>
  </tr>
  <tr>
    <td>statistics</td>
    <td>Objects</td>
    <td>Sim</td>
    <td>Representação dos dados estatísticos para um URL
	An object representing the statistical information for one particular source URL.</td>
  </tr>
  <tr>
    <td>nbVisits</td>
    <td>integer</td>
    <td>Sim</td>
    <td>Número total de visitas ao URL</td>
  </tr>
  <tr>
    <td>originatingCountry</td>
    <td>string</td>
    <td>Sim</td>
    <td>País de onde as visitas são originadas no acesso ao URL.</td>
  </tr>
  <tr>
    <td>country</td>
    <td>String enum</td>
    <td>Sim</td>
    <td>Código ‘ISO 3166-1 alpha-2’ do País
	
Enumerado:

<ul>
  <li>AT</li>
  <li>BE</li>
  <li>BG</li>
  <li>CY</li>
  <li>CZ</li>
  <li>DE</li>
  <li>DK</li>
  <li>EE</li>
  <li>EL</li>
  <li>ES</li>
  <li>FI</li>
  <li>FR</li>
  <li>HR</li>
  <li>HU</li>
  <li>IE</li>
  <li>IS</li>
  <li>LT</li>
  <li>LI</li>
  <li>LU</li>
  <li>LV</li>
  <li>MT</li>
  <li>NL</li>
  <li>NO</li>
  <li>PL</li>
  <li>PT</li>
  <li>RO</li>
  <li>SE</li>
  <li>SI</li>
  <li>SK</li>
</ul>
    	
 </td>
  </tr>
  <tr>
    <td>deviceType</td>
    <td>string</td>
    <td>Sim</td>
    <td>Tipo de dispositivo utilizado para visitar o URL
<ul>
 <li>Mobile</li>
  <li>Tablet</li>
  <li>PC</li>
</ul>
 </td>
  </tr>

  <tr>
    <td colspan="4" >Resposta</td>
 
  </tr>
  <tr>
    <th colspan="2">Código</th>
    <th colspan="2">Mensagem</th>
   
  </tr>
  <tr>
    <td colspan="2">200</td>
    <td colspan="2">OK</td>
   
  </tr>
</table>


 Exemplo de payload:
```markdown
 
  "isSDG": true,
  "content": [
    {
      "uniqueId": "123456789",
      "referencePeriod": {
        "startDate": "2020-01-01 00:00:00",
        "endDate": "2020-01-31 00:00:00"
      },
      "transferDate": "2020-02-01 00:00:00",
      "transferType": "API",
      "nbEntries": 1,
      "sources": [
        {
          "source": {
            "sourceUrl": "http://www1.ipq.pt/PT/IPQ/Pages/IPQ.aspx",
            "statistics": [
              {
                "deviceType": "Mobile",
                "nbVisits": 1,
                "originatingCountry": "TR"
              },
              {
                "deviceType": "PC",
                "nbVisits": 1,
                "originatingCountry": "IQ"
              }
            ]
          }
        }
      ]
    },
    {
      "uniqueId": "987654321",
      "referencePeriod": {
        "startDate": "2020-02-01 00:00:00",
        "endDate": "2020-02-29 00:00:00"
      },
      "transferDate": "2020-03-01 00:00:00",
      "transferType": "API",
      "nbEntries": 1,
      "sources": [
        {
          "source": {
            "sourceUrl": "http://www1.ipq.pt/PT/IPQ/Pages/IPQ.aspx",
            "statistics": [
              {
                "deviceType": "Mobile",
                "nbVisits": 1,
                "originatingCountry": "TR"
              },
              {
                "deviceType": "Tablet",
                "nbVisits": 1,
                "originatingCountry": "RS"
              }
            ]
          }
        }
      ]
    }
  ]
}

```
[Consultar o swagger](informationService.html)


# 3. Estatísticas de  serviços de assistência
Esta API serve para transferir dados estatítisticos de assistência e resolução de problemas para um  intervalo de tempo .
A frequência de envio deve ser mensal. Não é possível enviar múltiplos intervalos de referência numa vez.
Esta API não permite enviar mensagens com tamanho superior a 10 mb , no caso disso acontecer os intervalos de referência devem ser dividos para respeitar o limite.
O pedido e a resposta estão explicados na tabela abaixo.


- Número de pedidos
- Assunto
- Categorias 
     - Cidadãos ou Negócio
	 - Transfronteiriço ou nacional
- Tempo médio de resposta num período de 6 meses
- Dados de contexto
- Frequência uma vez por mês



 Exemplo de payload:
 
 
<table>
  <tr>
    <th colspan="4">Pedido</th>   
  </tr>
  <tr>
    <th>Parâmetros</th>
    <th>Tipo</th>
    <th>Obrigatório (Sim/ Não)</th>
    <th>Comentários</th>
  </tr>
  <tr>
    <td>isSDG</td>
    <td>boolean</td>
    <td>Sim</td>
    <td>A informação enviada está a ser enviada no âmbito do SDG?</td>
  </tr>
  <tr>
    <td>assistanceServiceStats</td>
    <td>Object</td>
    <td>Sim</td>
    <td>Representação dos serviços de assistência</td>
  </tr>
   <tr>
    <td>uniqueId</td>
    <td>string</td>
    <td>Sim</td>
    <td>O identificador único para o envio das estatísticas dos  serviços informativos para um intervalo de referência específico que é obtido através da api de Identificador Único</td>
  </tr>
  <tr>
    <td>referencePeriod</td>
    <td>object</td>
    <td>Sim</td>
    <td>Intervalo de referência</td>
  </tr>
 <tr>
    <td>startDate</td>
    <td>string</td>
    <td>Sim</td>
    <td>Data de ínicio do intervalo de referência</td>
  </tr>
  <tr>
    <td>endDate</td>
    <td>string</td>
    <td>Sim</td>
    <td>Data de fim do intervalo de referência</td>
  </tr>
 <tr>
    <td>transferDate</td>
    <td>string</td>
    <td>Sim</td>
    <td>Data e hora em que estamos a invocar a API</td>
  </tr>
  <tr>
    <td>transferType</td>
    <td>String (enum)</td>
    <td>Sim</td>
    <td>Tipo de transferência de dados, neste caso será 'API'</td>
  </tr>
 
  <tr>
    <td>nbEntries</td>
    <td>integer</td>
    <td>Sim</td>
    <td>Número de entradas , incluindo todas as fontes de URL's para as estatísticas que estão a ser enviadas</td>
  </tr>
 <tr>
    <td>sources</td>
    <td>Array of Objects</td>
    <td>Sim</td>
    <td>Representação da informação estatística sobre uma URL . Um objeto pode referenciar vários URLs</td>
  </tr>
  <tr>
    <td>source</td>
    <td>object</td>
    <td>Sim</td>
    <td>Dados estatísticos</td>
  </tr>
  <tr>
    <td>sourceUrl</td>
    <td>string</td>
    <td>Sim</td>
    <td>URL através do qual os dados estão a ser obtidos.</td>
  </tr> 
  <tr>
    <td>statistics</td>
    <td>Objects</td>
    <td>Sim</td>
    <td>Representação dos dados estatísticos para um URL
	An object representing the statistical information for one particular source URL</td>
  </tr>

  <tr>
    <td>urlStatistics</td>
    <td>Array of Objects</td>
    <td>Sim</td>
    <td>
	Representação de estatísticas de pedidos de assistência ou de solução de problemas</td>
  </tr>
  <tr>
    <td>nbRequests</td>
    <td>integer</td>
    <td>Sim</td>
    <td>Número total de pedidos  de assistência e pedido de solução de problemas</td>
  </tr>
  <tr>
    <td>categoryOfUser</td>
    <td>String (enum)</td>
    <td>Sim</td>
    <td>Categorias de utilizador "Cidadão" ou "Negócio"</td>
  </tr>
  <tr>
    <td>subjectMatter</td>
    <td>string</td>
    <td>Sim</td>
    <td>Categorias de serviços de assistência, a ser disponibilizadas oportunamente.
		<!--<ul>
		  <li>Starting business</li>
		   <li>Registering a company</li>
		   <li>Needing a licence, permit or certificate to start or continue an activity</li>
		   <li>Registering Intellectual Property</li>
		   <li>Registering a branch</li>
		   <li>Starting a new activity</li>
		   <li>Financing a company</li>
		   <li>Hiring an employee</li>
		   <li>Starting cross-border business</li>
		   <li>Registering a cross-border business</li>
		   <li>Registering a branch</li>
		   <li>Doing business</li>
		   <li>Financing a company</li>
		   <li>Needing a licence, permit or certificate to start or continue an activity</li>
		   <li>Registering Intellectual Property</li>
		   <li>Hiring an employee</li>
		   <li>Participating in public procurement</li>
		   <li>Notifying and reporting to authorities</li>
		   <li>Starting a new activity</li>
		   <li>Registering a branch</li>
		   <li>Having problems in paying creditors</li>
		   <li>Closing business</li>
		   <li>Restructuring of a company</li>
		   <li>Dissolution of a company</li>
		   <li>Closing business</li>
		   <li>Restructuring of a company</li>
		   <li>Dissolution of a company</li>
		   <li>Having a child</li>
		   <li>Starting education</li>
		   <li>Looking for a new job</li>
		   <li>Losing/quitting a job</li>
		   <li>Looking for a place to live</li>
		   <li>Changing relationship status</li>
		   <li>Driving a vehicle</li>
		   <li>Travelling abroad</li>
		   <li>Moving to/from the country</li>
		   <li>Facing an emergency / health problem</li>
		   <li>Facing a crime</li>
		</ul> -->
       
    </td> 
  </tr>
  <tr>
    <td>situationOfUser</td>
    <td>string (enum)</td>
    <td>Sim</td>
    <td>Situação do utilizador Transfronteiriço "cross-border", Nacional "national"</td>
  </tr>
  <tr>
    <td>avgResponseTime</td>
    <td>integer</td>
    <td>Sim</td>
    <td>tempo médio de resposta em dias</td>
  </tr>
 
  <tr>
    <th colspan="4">Response</th>
  </tr>
  <tr>
    <th colspan="2">Código</th>
    <th colspan="2">Mensagem</th>   
  </tr>
  <tr>
    <td colspan="2">200</td>
    <td colspan="2">OK</td>
  </tr>
 
 
</table>
 
```markdown

{
  "isSDG": true,
  "content": [
    {
      "uniqueId": "123456789",
      "referencePeriod": {
        "startDate": "2020-01-01 00:00:00",
        "endDate": "2020-01-31 00:00:00"
      },
      "transferDate": "2020-02-01 00:00:00",
      "transferType": "API",
      "nbEntries": 1,
      "sources": [
        {
          "source": {
            "sourceUrl": "https://www.iprhelpdesk.eu/",
            "statistics": [
              {
                "avgResponseTime": 223200000,
                "categoryOfUser": "business",
                "nbRequests": 1,
                "situationOfUser": "national",
                "subjectMatter": "Starting cross-border business"
              },
              {
                "avgResponseTime": 226800000,
                "categoryOfUser": "citizen",
                "nbRequests": 2,
                "situationOfUser": "cross-border",
                "subjectMatter": "Starting education"
              }
            ]
          }
        }
      ]
    },
    {
      "uniqueId": "987654321",
      "referencePeriod": {
        "startDate": "2020-02-01 00:00:00",
        "endDate": "2020-02-29 00:00:00"
      },
      "transferDate": "2020-03-01 00:00:00",
      "transferType": "API",
      "nbEntries": 1,
      "sources": [
        {
          "source": {
            "sourceUrl": "https://www.iprhelpdesk.eu/",
            "statistics": [
              {
                "avgResponseTime": 244800000,
                "categoryOfUser": "business",
                "nbRequests": 2,
                "situationOfUser": "national",
                "subjectMatter": "Starting cross-border business"
              },
              {
                "avgResponseTime": 147600000,
                "categoryOfUser": "citizen",
                "nbRequests": 2,
                "situationOfUser": "cross-border",
                "subjectMatter": "Starting education"
              }
            ]
          }
        }
      ]
    }
  ]
}
```
[Consultar o swagger](assistanceService.html)

# 4. Retorno de Informação \ Feedback de 1º nível
Esta Web API deve ser usada para recolher dados do feedback de 1º nível do utilizador sobre os serviços informativos, assistência, de resolução de problemas e de procedimentos online.
O pedido e a resposta estão explicados na tabela abaixo.


<table>
  <tr>
    <th colspan="4">Pedido</th>   
  </tr>
  <tr>
    <th>Parâmetros</th>
    <th>Tipo</th>
    <th>Obrigatório (Sim/ Não)</th>
    <th>Comentários</th>
  </tr>
  <tr>
    <td>isSDG</td>
    <td>boolean</td>
    <td>Sim</td>
  
 </tr>
 <tr>
    <td>uniqueId</td>
    <td>string</td>
    <td>Sim</td>
    <td>O identificador único para o envio das estatísticas dos  serviços informativos para um intervalo de referência específico que é obtido através da api de Identificador Único</td>
  </tr>
  <tr>
    <td>feedback</td>
    <td>object</td>
    <td>Não</td>
    <td>Armazena a informação de um feedback simples</td>
  </tr>
  <tr>
    <td>category</td>
    <td>string (enum)</td>
    <td>Sim</td>
    <td>Categorias "Information", "Procedure", "Assistance"</td>
  </tr>
  <tr>
    <td>rating</td>
    <td>Integer (enum)</td>
    <td>Sim</td>
    <td>Avaliação dos serviços entre 1,2,3,4,5</td>
  </tr>
  <tr>
    <td>source</td>
    <td>string</td>
    <td>Sim</td>
    <td>URL do serviço. Se o URL não estiver presente, por exemplo nos serviços de assistência, devemos utilizar o identificador do serviço no repositório SDG.</td>
  </tr>
   <tr>
    <td>helpUsImprove</td>
    <td>string</td>
    <td>Não</td>
    <td>Informação em texto livre enviada pelo utilizador</td>
  </tr>
  <tr>
    <td>foundInformation</td>
    <td>String (enum)</td>
    <td>Não</td>
    <td>Relativamente aos serviços informativos apenas. Uma das três opções  ["Yes", "No", "Partly"].</td>
  </tr>
   <tr>
    <td>feedbackBatch</td>
    <td>object</td>
    <td>Não</td>
    <td>Dados de feedback para um intervalo de referência</td>
  </tr>
  <tr>
    <td>referencePeriod</td>
    <td>object</td>
    <td>Sim</td>
    <td>Data de inicio e data de fim</td>
  </tr>
  <tr>
    <td>startDate</td>
    <td>string</td>
    <td>Sim</td>
    <td>Inicio do intervalo de referência
Exemplo: "2020-01-01 00:00:00"</td>
  </tr>
  <tr>
    <td>endDate</td>
    <td>string</td>
    <td>Sim</td>
    <td>Fim do intervalo de referência
Exemplo: 2020-01-31 00:00:00"</td>
  </tr>
  <tr>
    <td>transferDate</td>
    <td>string</td>
    <td>Sim</td>
    <td>Data de quando a API foi invocada
Exemplo: "2020-02-01 00:00:00"</td>
  </tr>
  <tr>
    <td>transferType</td>
    <td>String (enum)</td>
    <td>Sim</td>
    <td>Tipo de transferência "API", "Manual". Para a invocação do web service vai ser sempre 'API'</td>
  </tr>
  <tr>
    <td>nbEntries</td>
    <td>integer</td>
    <td>Sim</td>
    <td>Número de entradas para os serviços para qual foi enviado feedback</td>
  </tr>
  <tr>
    <td>feedbacks</td>
    <td>Array of Objects</td>
    <td>yes</td>
    <td>Representação de um conjunto de ‘feedbacks’.</td>
  </tr>
 
  <tr>
    <th colspan="4">Response</th>
  </tr>
  <tr>
    <th colspan="2">Code</th>
    <th colspan="2">Message</th>
  
  </tr>
  <tr>
    <td colspan="2">200</td>
    <td colspan="2">OK</td>
  </tr>
</table>


Exemplo de payload:

```markdown
{
  "isSDG": true,
  "content": [
    {
      "uniqueId": "123456789",
      "referencePeriod": {
        "startDate": "2020-01-01 00:00:00",
        "endDate": "2020-01-31 00:00:00"
      },
      "transferDate": "2020-02-01 00:00:00",
      "transferType": "API",
      "nbEntries": 2,
      "feedbacks": [
        {
          "feedback": {
            "category": "Procedure",
            "rating": 1,
            "source": "www.konsumenteuropa.se",
            "foundInformation": "Yes",
            "helpUsImprove": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
          }
        },
        {
          "feedback": {
            "category": "Information",
            "rating": 2,
            "source": "http://www.amsfl.li/ ",
            "foundInformation": "Partly",
            "helpUsImprove": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
          }
        }
      ]
    },
    {
      "uniqueId": "98765421",
      "referencePeriod": {
        "startDate": "2020-02-01 00:00:00",
        "endDate": "2020-02-29 00:00:00"
      },
      "transferDate": "2020-03-01 00:00:00",
      "transferType": "API",
      "nbEntries": 2,
      "feedbacks": [
        {
          "feedback": {
            "category": "Assistance",
            "rating": 5,
            "source": "http://www.moi.gov.cy/moi/moi.nsf/All/6D6489AF90B208F4C2257B89002E03F3",
            "foundInformation": "Partly",
            "helpUsImprove": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
          }
        },
        {
          "feedback": {
            "category": "Procedure",
            "rating": 1,
            "source": "https://www.odrcontactpoint.uk/",
            "foundInformation": "Yes",
            "helpUsImprove": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
          }
        }
      ]
    }
  ]
}

```
[Consultar o swagger](feedback1stLevel.html)


# 5. Retorno de Informação \ Feedback de 2º nível



Esta Web API deve ser usada para recolher dados do feedback de 2º nível do utilizador sobre os serviços informativos, assistência, de resolução de problemas e de procedimentos online.
O pedido e a resposta estão explicados na tabela abaixo.


As perguntas disponíveis para o questionáriod de segundo nível para os diferentes tipos de serviço vão ser descritas nas tabelas abaixo:

## 5.1. Retorno de Informação \ Feedback de 2º nível sobre serviços Informativos


- Encontrou o que procurava? (opções exclusivas: SIM/NÃO/PARCIALMENTE) 
- Avaliar esta página (Pontuação através de estrelas: de 1 a 5)
- Ajude-nos a melhorar (caixa de texto aberta) – campo opcional*
- Dados de contexto
- Questionário adicional
- Frequência uma vez por mês

Exemplo de payload:

```markdown

 {
          "feedback": {
            "category": "Information",
            "source": "https://www.bbl.admin.ch/bbl/fr/home/themen/fachbereich-bauprodukte/produkteinformationsstelle.html",
            "survey": {
              "accuracy": 1,
              "clarity": 1,
              "comprehensiveness": 5,
              "easyFinding": 1,
              "englishAvailability": "Unknown",
              "lastUpdate": "Unknown",
              "legalActs": "Irrelevant",
              "ownership": "Yes",
              "structure": 4,
              "upToDate": 2,
              "userFriendliness": 2
            }
          }
        }
```

[Consultar o swagger](feedback2ndLevel.html)
## 5.2. Retorno de Informação \ Feedback de 2º nível sobre serviços de assistência

- Avaliação do serviço fornecido (1 a 5 estrelas) – campo obrigatório *
- Ajude-nos a melhorar (caixa de texto aberta) – campo opcional*
- Dados de contexto
- Questionário adicional
- Frequência uma vez por mês


Exemplo de payload:

```markdown
{
          "feedback": {
            "category": "Assistance",
            "source": "https://eportugal.gov.pt/en/inicio/espaco-empresa",
            "survey": {
              "clearOffer": 1,
              "delays": "Yes",
              "easiness": 5,
              "onlinePayment": "Irrelevant",
              "responsiveness": 2
            }
          }
}
```
[Consultar o swagger](feedback2ndLevel.html)

## 5.3. Retorno de Informação \ Feedback de 2º nível sobre procedimentos\serviços on-line

- Avalie este procedimento?  (Pontuação através de estrelas: de 1 a 5)
- Ajude-nos a melhorar (caixa de texto aberta) – campo opcional*
- Dados de contexto
- Questionário adicional
- Frequência uma vez por mês

Exemplo de payload:

```markdown
{
          "feedback": {
            "category": "Procedure",
            "source": "http://www.sist.si/contact-point/information",
            "survey": {
              "complianceEvidence": "Irrelevant",
              "easiness": 2,
              "englishAvailability": "No",
              "nationalAuthentication": "Irrelevant",
              "onlinePayment": "Irrelevant"
            }
          }
}
```
[Consultar o swagger](feedback2ndLevel.html)