import {Card} from "antd";
import Button from "antd/es/button/button";
import {Cardtitle} from "@/app/components/Cardtitle";
import {CreateUpdateTask} from "@/app/components/CreateUpdateTask";
import {DeleteModelTask} from "@/app/components/DeleteModelTask";
import {useState} from "react";

interface Props {
    tasks: Task[];
    handleDelete: (id: string) => void;
    handleOpen: (task: Task) => void;
}

export const Tasks = ({tasks, handleDelete, handleOpen}: Props) => {
    const [isModalOpen, setModalOpen] = useState<boolean>(false);
    const [id, setId] = useState<string>("");
    function handleDeleteOnClick(id: string) 
    {
        handleDelete(id);
        CloseModal();
    }
    function OnDeleteClick(id: string) 
    {
        setId(id);
        OpenModal();
    }
    function OpenModal() 
    {
        setModalOpen(true);
    }
    function CloseModal() 
    {
        setModalOpen(false);
    }
    
    return (
        <div className={"cards"}>
            {tasks.map((task : Task) => (
                <Card 
                    key={task.id} 
                    title={<Cardtitle title={task.title}/>}
                    bordered={false}
                >
                    <p>{task.description}</p>
                    <div className={"card__button"}>
                        <Button 
                            onClick={() => handleOpen(task)} 
                            style={{flex: 1}}
                        >
                            Редактировать
                        </Button>
                        <Button
                            onClick={() => OnDeleteClick(task.id)}
                            danger
                            style={{flex: 1}}
                        >
                            Удалить
                        </Button>
                    </div>
                    
                    <DeleteModelTask 
                        isModalOpen={isModalOpen}
                        taskId={id}
                        handleOnOk={handleDeleteOnClick} 
                        handleOnCancel={CloseModal}
                    />
                    
                </Card>
            ))}
        </div>
    )
}