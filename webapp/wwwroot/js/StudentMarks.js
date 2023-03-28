// I was not able to get DbContext or MVC to work, therefore I had to resort to
// JavaScript and cookies (localStorage) to store students
// I transpiled my C# methods to JS so the calculations are still the same

let studentDBJSON = {}
let addStudentBtn = document.getElementById("addStudentBtn") || {}
let studentSection = document.getElementById("studentSection")

localStorage.getItem("students") || localStorage.setItem("students", JSON.stringify(studentDBJSON))

let studentCookie = localStorage.getItem("students")

addStudentBtn.onclick = function () {

    let studentName = document.getElementById("studentName").value
    let studentMark = document.getElementById("studentMark").value

    studentDBJSON = { ...studentDBJSON, [studentName] : Number(studentMark)}
    localStorage.setItem("students", JSON.stringify(studentDBJSON))

    updateDisplay()

    document.getElementById("studentName").value = ''
    document.getElementById("studentMark").value = ''
}
function updateDisplay() {
    studentSection.innerHTML = ''

    let studentDBLength = Object.keys(studentDBJSON).length

    for (const name in studentDBJSON) {
        let newStudentDisplayHTML = getStudentHTML(name, studentDBJSON[name], studentDBLength)
        studentSection.innerHTML += newStudentDisplayHTML
    }
}
function getStudentHTML(name, mark, length) {
    return `
    <ol class="list-group">
        <li class="list-group-item">
            <a id="studentName${length}">Name: ${name}</a>
        </li>
        <li class="list-group-item">
            <a id="studentMark${length}">Mark: ${mark}</a>
        </li>
    </ol>
`
}
class Students {
    constructor(students) {
        this.students = students
        this.studentsLength = Object.keys(students).length
    }
    FindGrade(grade) {
        if (grade <= 39) return 'F';
        else if (grade >= 40 && grade < 50) return 'D';
        else if (grade >= 50 && grade < 60) return 'C';
        else if (grade >= 60 && grade < 70) return 'B';
        else if (grade >= 75 && grade < 101) return 'A';

        return 'A';
    }
    getGradeProfile() {
        let grades = {
            A: 0,
            B: 0,
            C: 0,
            D: 0,
            F: 0,
        }
        for (const student in this.students) {
            switch (this.FindGrade(this.students[student])) {
                case 'A':
                    grades.A++;
                    break;
                case 'B':
                    grades.B++;
                    break;
                case 'C':
                    grades.C++;
                    break;
                case 'D':
                    grades.D++;
                    break;
                case 'F':
                    grades.F++;
                    break;
            }
        }
        for (const grade in grades) {
            grades[grade] = Math.round((grades[grade] / this.studentLength) * 100)
        }
        return grades
    }
    get min() {
        let minMark = 0
        for (const student in this.students)
            if (minMark > this.students[student] || minMark === 0)
                minMark = this.students[student]
        return minMark
    }
    get max() {
        let maxMark = 0
        for (const student in this.students)
            if (maxMark < this.students[student])
                maxMark = this.students[student]
        return maxMark
    }
    get mean() {
        let meanMark = 0
        for (const student in this.students) {
            meanMark += this.students[student]
        }
        return Math.round(meanMark / this.studentsLength)
    }
}


if (location.href.includes('studentmarksanalyse')) addStudentAnalytics()

function getStudentGradeHTML(name, grade) {
    return `
  <div class="grade">
    ${name}: ${grade}%
  </div>
`
} 

function addStudentAnalytics() {
    let studentCookie = JSON.parse(localStorage.getItem('students'))
    let studentGrades = new Students(studentCookie)
    let studentAnalyseID = document.getElementById('studentAnalyse')
    let gradeProfile = studentGrades.getGradeProfile()
    let studentGradeArray = [['test', 'test']]

    document.getElementById('numStudents').innerText = studentGrades.studentsLength
    document.getElementById('minStudents').innerText = studentGrades.min
    document.getElementById('maxStudents').innerText = studentGrades.max
    document.getElementById('meanStudents').innerText = studentGrades.mean

    for (grade in gradeProfile) {
        studentAnalyseID.innerHTML += getStudentGradeHTML(grade, gradeProfile[grade])
        studentGradeArray.push([grade, gradeProfile[grade]])
    }

    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(function () { drawChart(studentGradeArray) });
}

function drawChart(chartArray) {
    var data = google.visualization.arrayToDataTable(chartArray);
    var options = {
        title: 'Student Grade Profile'
    };
    var chart = new google.visualization.PieChart(document.getElementById('piechart'));
    chart.draw(data, options);
}
