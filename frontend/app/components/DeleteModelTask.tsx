import {Modal} from "antd";

interface Props {
    taskId: string;
    isModalOpen: boolean;
    handleOnOk: (id: string) => void;
    handleOnCancel: () => void;
}

export const DeleteModelTask = ({
    isModalOpen, 
    handleOnOk,
    handleOnCancel,
    taskId
} : Props) => {
    return (
        <Modal
            title={"Вы уверенны, что хотите удалить задачу?"}
            open={isModalOpen}
            cancelText={"Отмена"}
            okText={"Удалить"}
            onOk={() => handleOnOk(taskId)}
            onCancel={() => handleOnCancel()}
        >
            
        </Modal>
    )
}