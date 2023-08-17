
/**
 * Save value to localstorage
 * @param key Name of the item
 * @param value Value of the item
 */
export const storageSave = (key: string, value: string) => {
    localStorage.setItem(key, JSON.stringify(value))
}

/**
 * Read value from localstorage
 * @param key Name of the item
 */

export const storageRead = (key: string) => {
    const data = localStorage.getItem(key)
    if(data) {
        return JSON.parse(data)
    }
}

/**
 * Delete value from localstorage
 * @param key Name of the item
 */

export const storageRemove = (key: string) => {
    const data = localStorage.getItem(key)
    if(data) {
        localStorage.removeItem(key)
    }
}