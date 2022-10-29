class Ticket{
    destination : string;
    price  :number;
    status : string;

    constructor(destinationName : string, price : number, status : string){
        this.destination = destinationName;
        this.price = price;
        this.status = status;
    }
}


var tickets: Array<Ticket> = [];

var inputArray = ['Philadelphia|94.20|available','New York City|95.99|available','New York City|95.99|sold','Boston|126.20|departed'];

function solve(cities , sortingMark){

   for(let cityInfo of cities){
        let currentCity = cityInfo.split('|');

        const ticket  =new Ticket(currentCity[0],Number(currentCity[1]),currentCity[2]);

        tickets.push(ticket);
   }

   if(sortingMark == 'destination'){
        tickets = tickets.sort((curr, next) =>
        curr.destination.localeCompare(next.destination)
      );
   }
   else if(sortingMark == 'price'){
    tickets = tickets.sort((curr, next) =>
    curr.price - next.price);
   }
   else if(sortingMark == 'status'){
    tickets = tickets.sort((curr, next) =>
    curr.status.localeCompare(next.status));
   }

   return tickets;
   
}

console.log(solve(inputArray,'destination'));