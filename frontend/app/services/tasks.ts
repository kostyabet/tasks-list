export interface TaskRequest {
    title: string;
    description: string;
}

export const getAllTasks = async () => {
    const response = await fetch("https://localhost:44395/Tasks");
    
    return response.json();
}

export const createTask = async (taskRequest: TaskRequest)=> {
    await fetch("https://localhost:44395/Tasks", {
        method: "POST",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(taskRequest),
    });
}

export const updateTask = async (id: string, taskRequest: TaskRequest)=> {
    await fetch(`https://localhost:44395/Tasks/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(taskRequest),
    });
}

export const deleteTask = async (id: string)=> {
    await fetch(`https://localhost:44395/Tasks/${id}`, {
        method: "DELETE",
    });
} 