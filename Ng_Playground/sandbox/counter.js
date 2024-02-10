var createCounter = function(init) {
    let number = init;
   
    const increment = function(){
         return number++;
    };

    const decrement = function(){
        return init--;
    }

    const reset = function(){
        init = number;
        return init;
    }

    return{
        increment, decrement, reset
    }
};

const counter = createCounter(5)
counter.increment(); // 6
counter.reset(); // 5
counter.decrement(); // 4