#include <iostream>
#include <fstream>
#include <cmath>
#include <vector>
using namespace std;
int main (void) {

bool tab [16] = { true, true, true, true, true ,true,true,true,true,true,true,true,true,true,true,true}; 


int pierwiastek=sqrt(16);

for (int i = 2; i < pierwiastek; i++)
            {
               {
                    for (int j = 2; j < 17;j++)
                    {
                        if(j%i==0)
						{
							tab[j]=false;
						}
                    }
                }
            }
            
 for (int j = 2; j < 16;j++)
                    {
                        cout<<tab[j]<<" "<<j<<endl;
                    }    
				
        
        




cout<<"\n\nNacisnij ENTER aby zakonczyc";
getchar();

return 0;
}


