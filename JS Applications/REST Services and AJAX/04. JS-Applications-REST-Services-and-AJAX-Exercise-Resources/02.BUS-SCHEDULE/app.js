function solve() {

    let next = `depot`;
    let name = ``;
    const input = {
        info() { return document.getElementById('info') },
        depart() { return document.getElementById('depart') },
        arrive() { return document.getElementById('arrive') }
    }


    function depart() {
        let URL = `https://judgetests.firebaseio.com/schedule/${next}.json`;
        fetch(URL)
            .then((x) => x.json())
            .then((result) => showInfo(result));

        function showInfo(data) {
            input.info().textContent = `Next stop ${data.name}`;
            name = data.name;
            next = data.next;
            disabled();
        }
    }
    function arrive() {
        input.info().textContent = `Arriving at ${name}`;
        disabled();
    }

    function disabled() {
        const but = input.arrive().disabled;
        if (but) {
            input.arrive().disabled = false;
            input.depart().disabled = true;
        }
        else {
            input.arrive().disabled = true;
            input.depart().disabled = false;
        }
    }

    return {
        depart,
        arrive
    };
}

let result = solve();