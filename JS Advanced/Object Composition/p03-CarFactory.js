function carFactory(obj) {

    function createEngine(hp) {
        const engine = {}
        if (hp <= 90) {
            engine.power = 90;
            engine.volume = 1800;
        } else if (hp <= 120) {
            engine.power = 120;
            engine.volume = 2400;
        } else if (hp <= 200) {
            engine.power = 200;
            engine.volume = 3500;
        }
        
        return engine;
    }
 
    function createCarriage(color, type) {
        const carriage = { color, type };
        return carriage;
    }
 
    function makeWheels(wheelSize) {
        let newSize = wheelSize % 2 == 0 ? wheelSize - 1 : wheelSize;
        const wheels = new Array(4).fill(newSize);
        return wheels;
    }

    return {
        model: obj.model,
        engine: createEngine(obj.power),
        carriage: createCarriage(obj.color, obj.carriage),
        wheels: makeWheels(obj.wheelsize)
    }
}