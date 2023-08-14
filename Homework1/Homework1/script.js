
var userList = document.getElementById("userList");

async function getUsers() {
    userList.innerHTML = "";
    const response = await fetch("/api/users");
    const users = await response.json();

    users.forEach(user => {
        const li = document.createElement("li");
        li.textContent = user;
        userList.appendChild(li);
    });
}

getUsers();