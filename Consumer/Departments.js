const API_BASE = "http://localhost:5213/api";

async function loadDepartments(){
        const res = await fetch(`${API_BASE}/department`);
    const data = await res.json();
    //console.log(data);
        const tbody = document.getElementById("deptTableBody");
    tbody.innerHTML = "";

    data.forEach(d => {
        const row = document.createElement("tr");
        row.innerHTML = `
            <td>${d.deptNumber}</td>
            <td>${d.name}</td>
            <td>${d.location}</td>
            <td>${d.students.join(", ")}</td>
            <td>${d.studentsCount}</td>
        `;
        tbody.appendChild(row);
    });
}

window.onload = loadDepartments;
document.getElementById("refreshBtn").addEventListener("click", loadDepartments);