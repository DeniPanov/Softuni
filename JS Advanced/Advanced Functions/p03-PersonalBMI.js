function calcBMI(namE, agE, weighT, heighT) {

    let personData = {
        name: '',
        personalInfo: {
            age: 0,
            weight: 0,
            height: 0
        },
        BMI: undefined,
        status: undefined
    };

    (function setter() {
        personData.name = namE;
        personData.personalInfo.age = agE;
        personData.personalInfo.weight = weighT;
        personData.personalInfo.height = heighT;
    })();

    (function setBMI() {
        let bmiCalc = Math.round(personData.personalInfo.weight
            / (Math.pow((personData.personalInfo.height / 100), 2)));
        personData.BMI = bmiCalc;
    })();

    (function setStatus() {
        let underweight = 'underweight';
        let normal = 'normal';
        let overweight = 'overweight';
        let obese = 'obese';
        let bmi = personData.BMI;
        bmi >= 30 ?
            personData.status = obese : bmi >= 25 ?
                personData.status = overweight : bmi >= 18.5 ?
                    personData.status = normal :
                    personData.status = underweight;
    })();

    (function setRecommendation() {
        let recommendation = 'admission required';
        personData.status == 'obese' ?
            personData.recommendation = recommendation : null;
    })();

    function name() {   // GET NAME
        return personData.name;
    }

    function age() {    // GET AGE
        return personData.personalInfo.age;
    }

    function weight() { // GET WEIGHT
        return personData.personalInfo.weight;
    }

    function height() { // GET HEIGHT
        return personData.personalInfo.height;
    }

    function BMI() {    // GET BMI
        return personData.BMI;
    }

    function status() { // GET STATUS
        return personData.status;
    }

    function resommendation() { // GET RECOMMENDATION
        if (personData.recommendation) {
            return personData.recommendation;
        }
    }

    return personData;
}