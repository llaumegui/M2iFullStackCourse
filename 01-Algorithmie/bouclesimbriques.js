function demo() {
  for (var i = 0; i < 6; i++) {
    let message = "";
    for (var j = 0; j < i; j++) {
        message+="O";
    }
    console.log(message+"X");
  }
}

function mult(){
  let message;
    for(var i =1;i<=10;i++){
      message = `table de ${i} : `;
      for(var j =1;j<=10;j++){
        message += `${i*j} `;
      }
      console.log(message);
    }
}

function rate(){
var tourcoing = 96809;
var years = 0;
while(tourcoing<120000){
  tourcoing+=Math.round(tourcoing*.0089);
years++;}
console.log(years);
}

function power(){
  let minNote = 20;
  let maxNote = 0;
  let average = 0;

  for(let i =0;i<20;i++){
    let note = Math.floor(Math.random()*21);

    if(note>maxNote)
      maxNote = note;
    if(note<minNote)
      minNote = note;

    average += note;
  }

  console.log(`plus petite note: ${minNote}\nplus grande note: ${maxNote}\nmoyenne: ${average/20}`);
}

function sum()
{
  let n = prompt("set a number");
let message = "";
  for(let i =1;i<=n;i++){
    message+= `${i} `;
    console.log(message);
  }
}

//demo();
//mult();
//rate();
//power();
//sum();