// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let studentDBJSON = {}

let addStudentBtn = document.getElementById("addStudentBtn")
let studentSection = document.getElementById("studentSection")

localStorage.getItem("students") || localStorage.setItem("students", JSON.stringify(studentDBJSON))

let studentCookie = localStorage.getItem("students")

addStudentBtn.onclick = function () {

    let studentName = document.getElementById("studentName").value
    let studentMark = document.getElementById("studentMark").value

    studentDBJSON = { ...studentDBJSON, [studentName] : studentMark}
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
            <button type="button" id="studentName${length}Edit">Edit</button>
        </li>
        <li class="list-group-item">
            <a id="studentMark${length}">Mark: ${mark}</a>
            <button type="button" id="studentMark${length}Edit">Edit</button>
        </li>
    </ol>
`
}
