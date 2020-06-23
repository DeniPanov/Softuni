function solve(worker) {
    const dizziness = worker.dizziness;
 
    if(dizziness === true) {
        worker.levelOfHydrated += (worker.weight * worker.experience) / 10;
        worker.dizziness = false;
    }
 
    return worker;
}