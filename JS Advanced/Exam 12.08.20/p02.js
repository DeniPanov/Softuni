function solveClasses() {
    class Hall {
        constructor(capacity, name) {
            this.capacity = capacity;
            this.name = name;
            this.events = [];
        }

        hallEvent(title) {
            let event = this.events.find(e => e === title);

            if (event !== undefined) {
                throw new Error("This event is already added!");
            }

            this.events.push(title);
            return "Event is added.";
        }

        close() {
            this.events.splice(0, this.events.length);
            return `${this.name} hall is closed.`;
        }

        toString() {
            let result = [`${this.name} hall - ${this.capacity}`];

            if (this.events.length > 0) {
                result.push(`Events: ${this.events.join(", ")}`);
            }

            return result.join("\n");
        }
    }

    class MovieTheater extends Hall {
        constructor( capacity, name, screenSize ) {
            super(capacity, name);

            this.events = [];
            this.screenSize = screenSize;
        }

        close() {
            let closed = [
                super.close(),
                "Аll screenings are over."
            ];

            return closed.join("\n");
        }

        toString() {
            let result = [
                super.toString(),
                `${this.name} is a movie theater with ${this.screenSize} screensize and ${this.capacity} seats capacity.`
            ]

            return result.join("\n");
        }
    }

    class ConcertHall extends Hall {
        constructor( capacity, name ) {
            super(capacity, name);

            this.events = [];
            this.performers = [];
        }

        hallEvents( title, performers ) {
            let event = this.events.find(e => e === title);

            if (event !== undefined) {
                throw new Error("This event is already added!");
            }

            event = [
                super.hallEvent(title),
            ];

            this.performers.push(performers);

            this.events.push(title);
            return "Event is added.";
        }

        close() {
            let closed = [
                super.close(),
                "Аll performances are over."
            ];

            return closed.join("\n");
        }

        toString() {
            let result = [
                super.toString()
            ];

            if (this.events.length > 0) {
                result.push(`Performers: ${this.performers.join(", ")}`);
            }

            return result.join("\n");
        }
    }

    return {
        Hall,
        MovieTheater,
        ConcertHall
    }
}

let classes = solveClasses();
let hall = new classes.Hall(20, 'Main');
console.log(hall.hallEvent('Breakfast Ideas'));
console.log(hall.hallEvent('Annual Charity Ball'));
console.log(hall.toString());
console.log(hall.close());

let movieHall = new classes.MovieTheater(10, 'Europe', '10m');
console.log(movieHall.hallEvent('Top Gun: Maverick'));
console.log(movieHall.toString());

let concert = new classes.ConcertHall(5000, 'Diamond');
console.log(concert.hallEvent('The Chromatica Ball', ['LADY GAGA']));
console.log(concert.toString());
console.log(concert.close());
console.log(concert.toString());
