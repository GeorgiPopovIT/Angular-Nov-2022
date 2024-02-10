let num : number;
num = 3;

console.log('dd :>> ', num);



interface Point{
    x : number;
    y : number;
    
     Hello(number : number) : number;
}

class PointV implements Point{
    Hello(number : number): number {
        return number;
    }
    x: number;
    y: number;

}
let point = new PointV();

console.log(point.Hello(7));