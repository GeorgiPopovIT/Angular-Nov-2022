var Ticket = /** @class */ (function () {
    function Ticket(destinationName, price, status) {
        this.destination = destinationName;
        this.price = price;
        this.status = status;
    }
    return Ticket;
}());
var tickets = [];
var inputArray = ['Philadelphia|94.20|available', 'New York City|95.99|available', 'New York City|95.99|sold', 'Boston|126.20|departed'];
function solve(cities, sortingMark) {
    for (var _i = 0, cities_1 = cities; _i < cities_1.length; _i++) {
        var cityInfo = cities_1[_i];
        var currentCity = cityInfo.split('|');
        var ticket = new Ticket(currentCity[0], Number(currentCity[1]), currentCity[2]);
        tickets.push(ticket);
    }
    if (sortingMark == 'destination') {
        tickets = tickets.sort(function (curr, next) {
            return curr.destination.localeCompare(next.destination);
        });
    }
    else if (sortingMark == 'price') {
        tickets = tickets.sort(function (curr, next) {
            return curr.price - next.price;
        });
    }
    else if (sortingMark == 'status') {
        tickets = tickets.sort(function (curr, next) {
            return curr.status.localeCompare(next.status);
        });
    }
    return tickets;
}
console.log(solve(inputArray, 'destination'));
