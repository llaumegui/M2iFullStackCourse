function mult9(){
    if (i<1)
        return;
    for(var i=1;i<=10;i++){
        console.log(i +" * 9 = "+ 9*i);
    }
}

function sum(number){
    let result = 0;
    for(var i=1;i<=number;i++)
        result += i;
    
        console.log(`le resultat de la somme de 1 à ${number} est : ${result}`);
}

//mult9();
//sum(4);