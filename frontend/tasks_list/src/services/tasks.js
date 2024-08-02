const Task = 
    {
        title: String,
        description: String,
    }

export const getAllTasks = async () => 
{
    const response = await fetch("https://localhost:44395/Tasks")
    
    return response.json();
}

export const createTask = async (Task) => 
{
    await fetch("https://localhost:44395/Tasks", {
        method: "POST",
        contentType: "application/json",
        body: JSON.stringify(Task),
    })
}

export const updateTask = async (id, Task) => 
{
    await fetch(`https://localhost:44395/Tasks/${id}`, {
        method: "PUT",
        contentType: "application/json",
        body: JSON.stringify(Task),
    })    
}

export const deleteBook = async (id) =>
{
    await fetch(`https://localhost:44395/Tasks/${id}`, {
        method: "DELETE",
    })
}