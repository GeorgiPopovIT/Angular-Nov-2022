class Box<T> {
    private _boxes : Array<T> = [];

    public add(element : T) : void{
        this._boxes.push(element);
    }

    public remove() : void{
        this._boxes.pop();
    }

     public getCount() {
        return this._boxes.length;
    }
}

export default Box;

const box = new Box<number>();
box.add(1);
box.add(2);
box.add(3);
console.log(box.getCount());
box.remove();
console.log(box.getCount());