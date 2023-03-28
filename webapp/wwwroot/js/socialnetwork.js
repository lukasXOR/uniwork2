class Post {
    constructor(id, username, message) {
        this.id = id
        this.username = username
        this.message = message
        this.timestamp = Date.now()
        this.likes = Math.round(Math.random() * 10000) + 1000
        this.comments = []
    }
    Like() {
        this.likes++
    }
    Unlike() {
        this.likes--
    }
    AddComent(user, message) {
        this.comments.push({ username: user, message: message })
    }
}
class MessagePost extends Post {
    constructor(id, data) {
        super(id, data.username, data.message)
    }
}
class PhotoPost extends Post {
    constructor(id, data) {
        super(id, data.username, data.message)
        this.fileName = data.fileName
    }
}

class Page {
    constructor() {
    }
    addPost(data) {
        document.getElementById('Post').insertAdjacentHTML('afterend', `
    <tr id="Post${data.id}">
         <td>${data.id}</td>
         <td>${data.username}</td>
         <td>${data.timestamp}</td>
         <td>${data.message}</td>
         <td>${data.likes}</td>
         <td>${data.comments}</td>
        <th><button type="button">Like</button></th>
        <th><button type="button">Comment</button></th>
    </tr>
    `)
    }
    RemovePost(id) {
        document.getElementById('Post' + id).remove()
    }
    display(posts) {
        document.getElementById('allPosts').innerHTML = `
            <caption>All Posts</caption>
                <tr id="Post" style="background-color: sienna">
                    <th>Post ID</th>
                    <th>Author</th>
                    <th>Message Type</th>
                    <th>Message</th>
                    <th>Likes</th>
                    <th>Comments</th>
                </tr>
        `
        posts.forEach(post => this.addPost(post))
    }
}




class NewsFeed extends Page {
    constructor() {
        super()
        this.posts = new Set()
        this.postTypes = {
            message: MessagePost,
            photo: PhotoPost
        }
        this.ID = 0
        this.populate()
    }
    populate() {
        for (let i = 0; i < 10; i++) {
            this.AddPost('message', { username: 'lukas', message: 'hello' })
        }
        this.RemovePost('id', 30)
        super.display(this.posts)
        
    }
    AddPost(type, data) {
        this.ID++
        this.posts.add(new this.postTypes[type](this.ID, data))
    }
    RemovePost(type, data) {
        if (type === 'all') this.posts.clear()
        this.posts.forEach(post => {
            if (post[type] === data) this.posts.delete(post)
        })
    }
    GetPost(type, data) { // type: message username id timestamp
        if (type === 'all') return this.posts
        var posts = new Set()
        for (const post of this.posts.values())
            if (post[type] === data) posts.add(post)
        return posts
    }
}



window.onload = (() => {
    window.document.body.onload = new NewsFeed
})  
