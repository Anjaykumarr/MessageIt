import api from "axios";

export const routes = {

    // To get buttons at loading time...
    async getButtons() {
        const {data} = await api.get("api/chatapp/GetButtons")
        return data;
    },


    // TO get next page extension...
    async nextPage(next) {
        const {data} = await api.get("api/chatapp/GetNavigation", { next });
        return data;
    }
}