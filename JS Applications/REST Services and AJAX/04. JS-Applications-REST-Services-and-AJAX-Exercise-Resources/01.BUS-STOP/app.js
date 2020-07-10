function getInfo() {
    const validIds = ["1287", "1308", "1327", "2334"];

    const input = {
        busStopId() { return document.getElementById('stopId').value },
        busStopName() { return document.getElementById('stopName') },
        buses() { return document.getElementById('buses') }
    };

    const stopId = input.busStopId();

    if (validIds.includes(stopId) === false) {
        input.busStopName().textContent = 'ERROR'
        document.getElementById('stopId').value = "";
        return;
    }

    const url = `https://judgetests.firebaseio.com/businfo/${stopId}.json`;
    fetch(url)
        .then((x) => x.json())
        .then((result) => showInfo(result));

    document.getElementById('stopId').value = "";
    document.getElementById('buses').textContent = "";

    function showInfo(data) {
        input.busStopName().textContent = data.name;
        Object.keys(data.buses).forEach((bus) => {
            const li = document.createElement('li');
            li.textContent = `Bus ${bus} arrives in ${data.buses[bus]}`;
            input.buses().appendChild(li);
        })
    }
}