const API_BASE = "http://localhost:5213/api";

async function addDepartment() {
    const name = document.getElementById("deptName").value.trim();
    const location = document.getElementById("deptLocation").value.trim();

    if (!name || !location) {
        document.getElementById("message").textContent = "Please fill in all fields";
        return;
    }

    const res = await fetch(`${API_BASE}/department`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ name, location })
    });

    if (res.ok) {
        document.getElementById("message").textContent = "Department added!";
        document.getElementById("deptName").value = "";
        document.getElementById("deptLocation").value = "";
    } else {
        const err = await res.json();
        document.getElementById("message").textContent = "Error: " + JSON.stringify(err.errors || err);
    }
}

document.getElementById("addBtn").addEventListener("click", addDepartment);