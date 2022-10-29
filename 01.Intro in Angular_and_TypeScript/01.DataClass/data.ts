class Data{
     method : string;
     uri : string;
     version : string;
     message : string;
     response : string;
     fulfilled : boolean;

     constructor(method : string, uri : string, version : string,
         message : string, response?, fulfilled : boolean = false ){
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = response;
        this.fulfilled = fulfilled;
     }
}

let myData = new Data('GET','http://google.com','HTTP/1.1','');
console.log(myData);