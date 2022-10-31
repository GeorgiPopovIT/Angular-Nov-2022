class KeyValuePair<T, U>{
    private key : T;
    private value : U;

    setKeyValuePair(key : T, value : U){
        this.key = key;
        this.value = value;
    }

    display() : string{
        return`key = ${this.key}, value = ${this.value}`;
    }
}

export default KeyValuePair;

const kvp = new KeyValuePair<Number,string>();
kvp.setKeyValuePair(1,"Pesho");
console.log(kvp.display())