using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Frontend.RestClient.Resources.GameResources.FullGame;
using System.IO;

namespace Frontend.RestClient
{
    public class RestClient
    {
        private const string WebServiceUrl = "http://172.23.144.1:52721/api/";

        public async Task<GameResource> GetFullGameByIdAsync(int id)
        {
            // var httpClient = new HttpClient();

            // var json = await httpClient.GetStringAsync(WebServiceUrl + "Game/FullGame" + id);


            var GameModel = JsonConvert.DeserializeObject<GameResource>(testData);

            return GameModel;
        }

        private const string testData = @"{
  'name': 'Testovačka aneb žádný hněv a žádná rvačka',
  'description': 'prostě test',
  'stops': [
    {
      'name': 'Start1',
      'isFinal': false,
      'isInitial': true,
      'state1Requirement': null,
      'state2Requirement': null,
      'state3Requirement': null,
      'state4Requirement': null,
      'opens': [
        {
          'opens': {
            'id': 3
          },
          'ifUnvisible': 2,
          'ifVisible': 0,
          'ifUnlocked': 0,
          'value': 1,
          'id': 1
        }
      ],
      'questions': [],
      'choicesOpenThis': [],
      'displayObjectsHints': [],
      'displayObjectsRewards': [
        {
          'displayObject': {
            'ownText': 'jestli tohle čteš, tak jsi odemknul stanoviště Start1',
            'positionInIntroduction': null,
            'title': 'Text ke Start1',
            'id': 1
          },
          'position': 0
        }
      ],
      'position': {
    'x': 49.94203389299708,
        'y': 14.32789404242657,
        'radius': 10,
        'description': 'Start1',
        'isVisibleAsStopPosition': true,
        'id': 1
      },
      'positionsDisplayAfterDisplay': [],
      'positionsDisplayAfterUnlock': [
        {
          'x': 49.942428258892555,
          'y': 14.328124644295231,
          'radius': 10,
          'description': 'Křižovatka ulice Rumunská',
          'isVisibleAsStopPosition': null,
          'id': 2
        }
      ],
      'passwords': [],
      'id': 1
    },
    {
    'name': 'Druhé stanoviště',
      'isFinal': false,
      'isInitial': false,
      'state1Requirement': null,
      'state2Requirement': 2,
      'state3Requirement': null,
      'state4Requirement': null,
      'opens': [],
      'questions': [
        {
        'choices': [
            {
            'text': 'h',
              'opensMapPositions': [
                {
                'x': 49.93806060061456,
                  'y': 14.335395377160488,
                  'radius': 10,
                  'description': 'Vyhlídka hladká skála',
                  'isVisibleAsStopPosition': null,
                  'id': 9
                }
              ],
              'id': 1
            },
            {
            'text': 'l',
              'opensMapPositions': [],
              'id': 2
            },
            {
            'text': 'E',
              'opensMapPositions': [],
              'id': 3
            },
            {
            'text': 'F',
              'opensMapPositions': [],
              'id': 4
            }
          ],
          'questionText': 'Nejlepší písmeno?',
          'choicesThatOpensThis': [],
          'id': 2
        }
      ],
      'choicesOpenThis': [],
      'displayObjectsHints': [
        {
        'displayObject': {
            'ownText': 'jestli tohle čteš, tak se ti zobrazilo stanoviště 2',
            'positionInIntroduction': null,
            'title': 'Stan2_1',
            'id': 3
          },
          'position': 2
        },
        {
        'displayObject': {
            'ownText': 'Kazakhstan',
            'positionInIntroduction': null,
            'title': 'Stan2_2',
            'id': 4
          },
          'position': 0
        }
      ],
      'displayObjectsRewards': [
        {
        'displayObject': {
            'ownText': 'jestli tohle čteš, tak se ti odemklo stanoviště 2',
            'positionInIntroduction': null,
            'title': 'Stan2_3',
            'id': 5
          },
          'position': 1
        }
      ],
      'position': {
        'x': 49.94402409777789,
        'y': 14.329278739093247,
        'radius': 10,
        'description': 'Druhé stanoviště',
        'isVisibleAsStopPosition': false,
        'id': 4
      },
      'positionsDisplayAfterDisplay': [
        {
        'x': 49.94385268643003,
          'y': 14.329319892657773,
          'radius': 50,
          'description': 'Přibližná pozice stanoviště 2',
          'isVisibleAsStopPosition': null,
          'id': 7
        }
      ],
      'positionsDisplayAfterUnlock': [],
      'passwords': [
        {
        'question': 'V jakém městě se nachází toto stanoviště?',
          'passwords': [
            {
            'password': 'Černošice',
              'useRegex': false,
              'diffUpperCase': false,
              'id': 5
            }
          ],
          'id': 2
        }
      ],
      'id': 3
    },
    {
    'name': 'Start2',
      'isFinal': false,
      'isInitial': true,
      'state1Requirement': null,
      'state2Requirement': null,
      'state3Requirement': null,
      'state4Requirement': null,
      'opens': [
        {
        'opens': {
            'id': 3
          },
          'ifUnvisible': 2,
          'ifVisible': 0,
          'ifUnlocked': 0,
          'value': 1,
          'id': 2
        }
      ],
      'questions': [],
      'choicesOpenThis': [],
      'displayObjectsHints': [
        {
        'displayObject': {
            'ownText': 'jestli tohle čteš, tak se ti zobrazilo stanoviště start2',
            'positionInIntroduction': null,
            'title': 'Text ke Start2',
            'id': 2
          },
          'position': 0
        }
      ],
      'displayObjectsRewards': [],
      'position': {
        'x': 49.94305641031893,
        'y': 14.329041161118013,
        'radius': 10,
        'description': 'Start2',
        'isVisibleAsStopPosition': true,
        'id': 3
      },
      'positionsDisplayAfterDisplay': [],
      'positionsDisplayAfterUnlock': [],
      'passwords': [
        {
        'question': 'Kolik je 1+1?',
          'passwords': [
            {
            'password': '2',
              'useRegex': false,
              'diffUpperCase': false,
              'id': 1
            },
            {
            'password': '11',
              'useRegex': false,
              'diffUpperCase': false,
              'id': 2
            },
            {
            'password': 'dva',
              'useRegex': false,
              'diffUpperCase': false,
              'id': 3
            },
            {
            'password': 'jedenáct',
              'useRegex': false,
              'diffUpperCase': false,
              'id': 4
            }
          ],
          'id': 1
        }
      ],
      'id': 2
    },
    {
    'name': 'Třetí stanoviště - špatně',
      'isFinal': false,
      'isInitial': false,
      'state1Requirement': null,
      'state2Requirement': 1,
      'state3Requirement': null,
      'state4Requirement': null,
      'opens': [
        {
        'opens': {
            'id': 3
          },
          'ifUnvisible': 0,
          'ifVisible': 0,
          'ifUnlocked': 2,
          'value': 2,
          'id': 3
        }
      ],
      'questions': [],
      'choicesOpenThis': [
        {
        'choiceOpensThis': {
            'text': 'l',
            'opensMapPositions': [],
            'id': 2
          },
          'ifUnvisible': 2,
          'ifVisible': 0,
          'ifUnlocked': 2,
          'value': 1,
          'id': 2
        },
        {
        'choiceOpensThis': {
            'text': 'E',
            'opensMapPositions': [],
            'id': 3
          },
          'ifUnvisible': 2,
          'ifVisible': 0,
          'ifUnlocked': 2,
          'value': 1,
          'id': 3
        },
        {
        'choiceOpensThis': {
            'text': 'F',
            'opensMapPositions': [],
            'id': 4
          },
          'ifUnvisible': 2,
          'ifVisible': 0,
          'ifUnlocked': 2,
          'value': 1,
          'id': 4
        }
      ],
      'displayObjectsHints': [],
      'displayObjectsRewards': [
        {
        'displayObject': {
            'ownText': 'jestli tohle čteš, tak jsi odemkl stanoviště 3 - špatně a musíš se vrátit na stanoviště 2',
            'positionInIntroduction': null,
            'title': 'Odpověděl jsi špatně na otázku u stanoviště 2',
            'id': 6
          },
          'position': 0
        }
      ],
      'position': {
        'x': 49.94503794225395,
        'y': 14.33010516194166,
        'radius': 10,
        'description': 'Třetí stanoviště - špatně',
        'isVisibleAsStopPosition': true,
        'id': 8
      },
      'positionsDisplayAfterDisplay': [],
      'positionsDisplayAfterUnlock': [],
      'passwords': [],
      'id': 4
    },
    {
    'name': 'Třetí stanoviště - správně',
      'isFinal': false,
      'isInitial': false,
      'state1Requirement': null,
      'state2Requirement': 1,
      'state3Requirement': null,
      'state4Requirement': null,
      'opens': [],
      'questions': [
        {
        'defaultChoice': {
            'opensMapPositions': [],
            'id': 7
          },
          'choices': [
            {
            'text': 'Ne',
              'useRegex': false,
              'diffUpperCase': false,
              'opensMapPositions': [],
              'id': 5
            },
            {
            'text': 'Ano',
              'useRegex': false,
              'diffUpperCase': false,
              'opensMapPositions': [],
              'id': 6
            },
            {
            'text': '42',
              'useRegex': false,
              'diffUpperCase': false,
              'opensMapPositions': [],
              'id': 8
            }
          ],
          'questionText': 'Zadej odpověď na základní otázku vesmíru.',
          'choicesThatOpensThis': [],
          'id': 3
        }
      ],
      'choicesOpenThis': [
        {
        'choiceOpensThis': {
            'text': 'h',
            'opensMapPositions': [
              {
                'x': 49.93806060061456,
                'y': 14.335395377160488,
                'radius': 10,
                'description': 'Vyhlídka hladká skála',
                'isVisibleAsStopPosition': null,
                'id': 9
              }
            ],
            'id': 1
          },
          'ifUnvisible': 2,
          'ifVisible': 0,
          'ifUnlocked': 0,
          'value': 1,
          'id': 1
        }
      ],
      'displayObjectsHints': [],
      'displayObjectsRewards': [],
      'position': {
        'x': 49.94453236871695,
        'y': 14.32903393928024,
        'radius': 10,
        'description': 'Třetí stanoviště - správně',
        'isVisibleAsStopPosition': true,
        'id': 10
      },
      'positionsDisplayAfterDisplay': [],
      'positionsDisplayAfterUnlock': [],
      'passwords': [],
      'id': 5
    },
    {
    'name': 'Čtvrté stanoviště - správně',
      'isFinal': true,
      'isInitial': false,
      'state1Requirement': null,
      'state2Requirement': 1,
      'state3Requirement': null,
      'state4Requirement': null,
      'opens': [],
      'questions': [],
      'choicesOpenThis': [
        {
        'choiceOpensThis': {
            'text': '42',
            'useRegex': false,
            'diffUpperCase': false,
            'opensMapPositions': [],
            'id': 8
          },
          'ifUnvisible': 2,
          'ifVisible': 0,
          'ifUnlocked': 0,
          'value': 1,
          'id': 8
        }
      ],
      'displayObjectsHints': [],
      'displayObjectsRewards': [],
      'position': {
        'x': 49.944473353325506,
        'y': 14.328192771961112,
        'radius': 10,
        'description': 'Cíl!',
        'isVisibleAsStopPosition': true,
        'id': 11
      },
      'positionsDisplayAfterDisplay': [],
      'positionsDisplayAfterUnlock': [],
      'passwords': [],
      'id': 6
    },
    {
    'name': 'Čtvrté stanoviště - špatně',
      'isFinal': false,
      'isInitial': false,
      'state1Requirement': null,
      'state2Requirement': 1,
      'state3Requirement': null,
      'state4Requirement': null,
      'opens': [
        {
        'opens': {
            'id': 5
          },
          'ifUnvisible': 0,
          'ifVisible': 0,
          'ifUnlocked': 2,
          'value': 1,
          'id': 5
        },
        {
        'opens': {
            'id': 7
          },
          'ifUnvisible': 0,
          'ifVisible': 1,
          'ifUnlocked': 1,
          'value': 1,
          'id': 6
        }
      ],
      'questions': [],
      'choicesOpenThis': [
        {
        'choiceOpensThis': {
            'text': 'Ne',
            'useRegex': false,
            'diffUpperCase': false,
            'opensMapPositions': [],
            'id': 5
          },
          'ifUnvisible': 2,
          'ifVisible': 0,
          'ifUnlocked': 0,
          'value': 1,
          'id': 5
        },
        {
        'choiceOpensThis': {
            'text': 'Ano',
            'useRegex': false,
            'diffUpperCase': false,
            'opensMapPositions': [],
            'id': 6
          },
          'ifUnvisible': 2,
          'ifVisible': 0,
          'ifUnlocked': 0,
          'value': 1,
          'id': 6
        },
        {
        'choiceOpensThis': {
            'opensMapPositions': [],
            'id': 7
          },
          'ifUnvisible': 2,
          'ifVisible': 0,
          'ifUnlocked': 0,
          'value': 1,
          'id': 7
        }
      ],
      'displayObjectsHints': [],
      'displayObjectsRewards': [],
      'position': null,
      'positionsDisplayAfterDisplay': [],
      'positionsDisplayAfterUnlock': [],
      'passwords': [
        {
        'question': 'Na tomto stanovišti stačí zadat heslo.',
          'passwords': [
            {
            'password': 'heslo',
              'useRegex': false,
              'diffUpperCase': true,
              'id': 8
            }
          ],
          'id': 3
        }
      ],
      'id': 7
    }
  ],
  'introduction': {
    'title': 'README',
    'mapPositions': [
      {
        'x': 49.939629868580155,
        'y': 14.324368631811852,
        'radius': 20,
        'description': 'Železniční most přes Berounku',
        'isVisibleAsStopPosition': null,
        'id': 13
      }
    ],
    'displayObjects': [
      {
        'ownText': 'Vítej u testovací hry, doufám, že to bude fungovat',
        'positionInIntroduction': 0,
        'title': 'Vítej u testovací hry',
        'id': 7
      }
    ],
    'id': 1
  },
  'owners': [
    {
      'userName': 'Alligator',
      'email': 'alligator@hrad.cz',
      'id': 1
    },
    {
    'userName': 'Jan Slíva',
      'email': 'jan.sliva@mensagymnazium.cz',
      'id': 4
    }
  ],
  'playingTime': 256,
  'limit': 512,
  'id': 1
}"; 
    }
}
