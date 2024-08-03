import {Card} from "antd";
import Button from "antd/es/button/button";
import {Cardtitle} from "@/app/components/Cardtitle";

interface Props {
    tasks: Task[];
    handleDelete: (id: string) => void;
    handleOpen: (task: Task) => void;
}

export const Tasks = ({tasks, handleDelete, handleOpen}: Props) => {
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
                            onClick={() => handleDelete(task.id)}
                            danger
                            style={{flex: 1}}
                        >
                            Удалить
                        </Button>
                    </div>
                </Card>
            ))}
        </div>
    )
}